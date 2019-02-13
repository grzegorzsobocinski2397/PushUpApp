using Xamarin.Forms;
using System;
using System.Globalization;

namespace PushUpApp
{
    public class BoolToBackgroundColorConverter : BaseValueConverter<BoolToBackgroundColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Creates default color 
            Color color = Color.CornflowerBlue;

            // Return color based on the value
            if ((bool)value)
            {
                color = Color.Orange;
                return color;
            }
            else
                return color;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
