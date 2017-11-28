using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Epiphany.Model
{
    public class Converter
    {
        public static int ToInt(string value, int defaultValue)
        {
            int returnValue = 0;
            if (!int.TryParse(value, out returnValue))
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }

        public static double ToDouble(string value, double defaultValue)
        {
            double returnValue = 0.0;
            if (!double.TryParse(value, out returnValue))
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }

        public static bool ToBool(string value, bool defaultValue)
        {
            bool returnValue = false;
            if (!bool.TryParse(value, out returnValue))
            {
                returnValue = defaultValue;
            }
            return returnValue;
        }

        public static DateTime ToDateTime(string dt)
        {
            DateTime dateTime = default(DateTime);
            if (!DateTime.TryParse(dt, out dateTime))
            {
                // Try the special format Mon Nov 27 19:56:49 -0800 2017
                string pattern = "ddd MMM dd HH:mm:ss zzz yyyy";
                DateTime.ParseExact(dt, pattern, CultureInfo.InvariantCulture);
                DateTime.TryParseExact(dt, pattern, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dateTime);
            }

            return dateTime;
        }

        public static string ToPlainText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return Regex.Replace(text, @"<[^>]*>", String.Empty);
        }
    }
}
