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

            // Based on the value return color
            if ((bool)value)
            {
                color = Color.Orange;
                return color;
            }
            else
            {
                return color;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
