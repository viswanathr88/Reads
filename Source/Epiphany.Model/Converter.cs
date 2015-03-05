using System;

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
            DateTime.TryParse(dt, out dateTime);
            return dateTime;
        }
    }
}
