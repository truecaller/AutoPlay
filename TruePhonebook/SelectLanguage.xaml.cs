using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TruePhonebook
{
    class Language
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectLanguage
    {
        public SelectLanguage()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                LanguageList.ItemsSource = new List<Language>
                {
                    new Language { Name = "English", Code = "en-US"},
                    new Language { Name = "العربية", Code = "ar"},
                    new Language { Name = "Deutsch", Code = "de"},
                    new Language { Name = "Klingon", Code = "kl"},
                };
            };
        }

        void OnLanguageSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedLanguage = (Language) LanguageList.SelectedItem;
            App.ActiveLanguage = selectedLanguage.Code;
            App.RootFrame.Navigate(typeof (MainPage));
        }
    }
}
