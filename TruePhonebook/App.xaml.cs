using System.Globalization;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TruePhonebook
{
    sealed partial class App
    {
        public static Frame RootFrame { get; private set; }

        static readonly IPropertySet LocalSettings = ApplicationData.Current.LocalSettings.Values;
        const string ActiveLanguageKey = "ActiveLanguage";
        public static string ActiveLanguage
        {
            get { return LocalSettings.ContainsKey(ActiveLanguageKey) ? LocalSettings[ActiveLanguageKey].ToString() : "en-US"; }
            set
            {
                LocalSettings[ActiveLanguageKey] = value;
                SetActiveLanguage(value);
            }
        }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(500, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            RootFrame = Window.Current.Content as Frame;

            if (RootFrame == null)
            {
                RootFrame = new Frame();
                Window.Current.Content = RootFrame;
            }

            SetActiveLanguage(ActiveLanguage);

            if (RootFrame.Content == null)
            {
                RootFrame.Navigate(typeof(MainPage), e.Arguments);
            }

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            if (e.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                SystemNavigationManager.GetForCurrentView().BackRequested -= App_BackRequested;
                SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
            }

            Window.Current.Activate();
        }

        static void App_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;

            if (RootFrame.CanGoBack)
                RootFrame.GoBack();
        }

        static void SetActiveLanguage(string languageCode)
        {
            var culture = new CultureInfo(languageCode);
            ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            //RootFrame.FlowDirection = culture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }
    }
}
