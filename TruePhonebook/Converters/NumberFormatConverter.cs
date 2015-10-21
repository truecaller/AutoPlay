using System;
using Windows.Globalization.NumberFormatting;
using Windows.UI.Xaml.Data;

namespace TruePhonebook.Converters
{
    class NumberFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return !string.IsNullOrWhiteSpace(value?.ToString()) ? new NumeralSystemTranslator().TranslateNumerals(value.ToString()) : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
