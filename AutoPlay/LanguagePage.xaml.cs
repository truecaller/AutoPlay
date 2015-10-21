using System.Globalization;

namespace AutoPlay
{
    public sealed partial class LanguagePage
    {
        public LanguagePage()
        {
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                var currentUiCulture = CultureInfo.DefaultThreadCurrentUICulture;
                status.Text = currentUiCulture.TwoLetterISOLanguageName == "kl" ? "Klingon" : CultureInfo.DefaultThreadCurrentUICulture.DisplayName;
            };
        }
    }
}
