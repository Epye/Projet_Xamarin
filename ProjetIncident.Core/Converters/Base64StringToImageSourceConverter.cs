using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace MobileExamples.Converters
{
    public class Base64StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                var base64String = value as string;
                byte[] imgBytes = Tools.Convert.Base64StringToBytes(base64String);
                return ImageSource.FromStream(() => new MemoryStream(imgBytes));
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
