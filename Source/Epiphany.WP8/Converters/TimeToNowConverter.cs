using Epiphany.Strings;
using System;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public class TimeToNowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = (DateTime)value;
            TimeSpan timeFromNow = DateTime.Now - dt;
            if ((int)timeFromNow.TotalSeconds < 60)
            {
                if ((int)timeFromNow.TotalSeconds <= 5)
                    return AppResources.JustAMomentAgoText;

                else
                    return string.Format(AppResources.NSecondsAgoText, (int)timeFromNow.TotalSeconds);
            }
            else if ((int)timeFromNow.TotalMinutes < 60)
            {
                if ((int)timeFromNow.TotalMinutes == 1)
                    return AppResources.OneMinuteAgoText;
                else
                    return string.Format(AppResources.NMinutesAgoText, (int)timeFromNow.TotalMinutes);
            }
            else if ((int)timeFromNow.TotalHours < 24)
            {
                if ((int)timeFromNow.TotalHours == 1)
                    return AppResources.OneHourAgoText;
                else
                    return string.Format(AppResources.AboutNHoursAgoText, (int)timeFromNow.TotalHours);
            }
            else if ((int)timeFromNow.TotalDays < 30)
            {
                if ((int)timeFromNow.TotalDays == 1)
                    return AppResources.OneDayAgoText;
                else
                    return string.Format(AppResources.NDaysAgoText, (int)timeFromNow.TotalDays);
            }
            else
            {
                if ((int)timeFromNow.TotalDays / 30 == 1)
                    return AppResources.OneMinuteAgoText;
                else
                    return string.Format(AppResources.NMonthsAgoText, (int)(timeFromNow.TotalDays / 30));
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
