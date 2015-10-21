using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace TruePhonebook.Converters
{
    class ArrowFlowDirectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // The questionmarks in blocks will be seen as two different arrows by the OS.
            return CultureInfo.DefaultThreadCurrentUICulture.TextInfo.IsRightToLeft ? "" : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
