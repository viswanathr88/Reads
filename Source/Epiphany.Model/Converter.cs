using System;

namespace Epiphany.Model
{
    public class Converter
    {
        public static int ToInt(string value, int defaultValue)
        {
            int returnValue = defaultValue;
            int.TryParse(value, out returnValue);
            return returnValue;
        }

        public static double ToDouble(string value, double defaultValue)
        {
            double returnValue = defaultValue;
            double.TryParse(value, out returnValue);
            return returnValue;
        }

        public static bool ToBool(string value, bool defaultValue)
        {
            bool returnValue = defaultValue;
            bool.TryParse(value, out returnValue);
            return returnValue;
        }

        public static DateTime ToDateTime(string dt)
        {
            DateTime dateTime = default(DateTime);
            DateTime.TryParse(dt, out dateTime);
            return dateTime;
        }
    }
}
