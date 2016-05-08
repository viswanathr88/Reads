using Epiphany.Strings;
using System;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.Converters
{
    public class TimeToNowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime dt = (DateTime)value;
            TimeSpan timeFromNow = DateTime.Now - dt;
            if ((int)timeFromNow.TotalSeconds < 60)
            {
                return string.Format(AppStrings.NSecondsAgoText, (int)timeFromNow.TotalSeconds);
            }
            else if ((int)timeFromNow.TotalMinutes < 60)
            {
                return string.Format(AppStrings.NMinutesAgoText, (int)timeFromNow.TotalMinutes);
            }
            else if ((int)timeFromNow.TotalHours < 24)
            {
                return string.Format(AppStrings.NHoursAgoText, (int)timeFromNow.TotalHours);

            }
            else if ((int)timeFromNow.TotalDays < 30)
            {
                return string.Format(AppStrings.NDaysAgoText, (int)timeFromNow.TotalDays);
            }
            else if ((int)timeFromNow.TotalDays < 365)
            {
                return string.Format(AppStrings.NMonthsAgoText, (int)(timeFromNow.TotalDays / 30));
            }
            else
            {
                return string.Format(AppStrings.NYearsAgoText, (int)(timeFromNow.TotalDays / 365));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
