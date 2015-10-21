using System;
using Windows.UI.Xaml.Data;
using TruePhonebook.Strings;

namespace TruePhonebook.Converters
{
    class NumberTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(string.IsNullOrWhiteSpace(value?.ToString()))
                return StringResources.AllKeys.NumberTypeOther;

            var numberType = value.ToString();

            switch (numberType)
            {
                case "Work":
                    return StringResources.AllKeys.NumberTypeWork;
                case "Home":
                    return StringResources.AllKeys.NumberTypeHome;
                case "Mobile":
                    return StringResources.AllKeys.NumberTypeMobile;
                case "Other":
                    return StringResources.AllKeys.NumberTypeOther;
            }

            return StringResources.AllKeys.NumberTypeOther;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
