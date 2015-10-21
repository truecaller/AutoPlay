using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using TruePhonebook;

namespace AutoPlay
{
    public static class AutoPlayManager
    {
        static script _script;

        static async Task InitAsync()
        {
            if (_script == null)
            {
                var storageFile = await Package.Current.InstalledLocation.GetFileAsync("script.xml");
                var stream = await storageFile.OpenStreamForReadAsync();
                var reader = XmlReader.Create(stream, new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
                _script = new XmlSerializer(typeof(script)).Deserialize(reader) as script;
            }
        }

        public static async Task RunAsync()
        {
            var lastActiveLanguage = App.ActiveLanguage;

            await InitAsync();

            // "Pictures library" capability is necessary to make that work
            var appFolder = await KnownFolders.PicturesLibrary.CreateFolderAsync("AutoPlay", CreationCollisionOption.OpenIfExists);
            var sessionFolder = await appFolder.CreateFolderAsync(DateTime.Now.ToString("yyyy-MM-dd HHmm", new CultureInfo("en-US")), CreationCollisionOption.OpenIfExists);

            foreach (var langSetting in _script.languageSettings)
            {
                App.ActiveLanguage = langSetting.key;
                await NavigateAsync<LanguagePage>();

                foreach (var pageScript in _script.pageProtocol)
                {
                    switch (pageScript.name)
                    {
                        case "MainPage":
                            var page = await NavigateAsync<MainPage>();

                            switch (pageScript.Action)
                            {
                                case "UnFocus":
                                    page.UnFocus();
                                    break;
                                case "SearchText":
                                    page.SearchText = langSetting.MainPage.Text;
                                    break;
                                case "SearchNumber":
                                    page.SearchText = langSetting.MainPage.Numeric;
                                    break;
                            }

                            break;
                    }

                    await Task.Delay(2000);

                    var filePath = pageScript.Action + ".png";

                    var languageFolder = await sessionFolder.CreateFolderAsync(langSetting.key + " (" + langSetting.key + ")",
                                CreationCollisionOption.OpenIfExists);

                    await ScreenGrabber.TakeSnapshotAsync(App.RootFrame, filePath, languageFolder);
                }
            }

            //Reset
            App.ActiveLanguage = lastActiveLanguage;
            await Task.Delay(1000);
            (await NavigateAsync<MainPage>()).SearchText = string.Empty;
        }

        static async Task<T> NavigateAsync<T>(object parameter = null) where T : Page
        {
            if (App.RootFrame.Content == null || App.RootFrame.Content.GetType() != typeof(T))
            {
                App.RootFrame.Navigate(typeof(T), parameter);
                await Task.Delay(2000);
            }

            return App.RootFrame.Content as T;
        }
    }
}
