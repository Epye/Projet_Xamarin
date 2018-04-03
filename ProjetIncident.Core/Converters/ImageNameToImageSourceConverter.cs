using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace ProjetIncident.Core.Converters
{
    public class ImageNameToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                return ImageSource.FromFile(value as string);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
