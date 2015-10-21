// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using AutoPlay;

namespace TruePhonebook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        MainPageViewModel ViewModel { get; }

        public string SearchText
        {
            get { return SearchTextBox.Text.Trim(); }
            set { SearchTextBox.Text = value; }
        }

        public MainPage()
        {
            InitializeComponent();
            ViewModel = (MainPageViewModel)DataContext;

            Loaded += (sender, args) =>
            {
                ViewModel.FilterContacts();
            };
        }

        void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.FilterContacts(SearchText);
        }

        async void OnAutoPlayClicked(object sender, RoutedEventArgs e)
        {
            await AutoPlayManager.RunAsync();
        }

        void OnSelectLanguageClicked(object sender, RoutedEventArgs e)
        {
            App.RootFrame.Navigate(typeof (SelectLanguage));
        }

        public void UnFocus()
        {
            SearchText = string.Empty;

            if (SearchTextBox.Equals(FocusManager.GetFocusedElement()))
            {
                DummyFocusableControl.Focus(FocusState.Programmatic);
            }
        }
    }
}
