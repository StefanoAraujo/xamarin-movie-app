using System;
using System.Globalization;
using Xamarin.Forms;

namespace MoviesMobileApp.Converters
{

    /// <summary>
    /// Converts rank percentage (0-100%) to rank color
    /// </summary>
    class RankIntToRankColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vote = (int)value;
            if (vote > 90)
            {
                return Color.FromHex("#801414");
            }
            else if (vote > 70)
            {
                return Color.FromHex("AF3535");
            }
            else if (vote > 60)
            {
                return Color.FromHex("#AD6969");
            }
            else if (vote > 50)
            {
                return Color.FromHex("#CACACA");
            }
            else if (vote > 30)
            {
                return Color.FromHex("#648D8D");
            }
            else
            { // really bad movie
                return Color.FromHex("#0C4D4D");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
