using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHFTGRAMAPP.Core.Operations
{
    public static class DataInput
    {
        public static decimal GetDecimalValue(this string s, decimal defaultvalue)
        {
            decimal rzlt = defaultvalue;

            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo culture = CultureInfo.InvariantCulture;
            object o = s;
            if (o != null)
                decimal.TryParse(o.ToString().Trim().Replace(",", "."), style, culture, out rzlt);

            return rzlt;
        }
        public static double GetDoubleValue(this string s, double defaultvalue)
        {
            double rzlt = defaultvalue;

            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo culture = CultureInfo.InvariantCulture;
            object o = s;
            if (o != null)
                double.TryParse(o.ToString().Trim().Replace(",", "."), style, culture, out rzlt);

            return rzlt;
        }
        public static long GetLongValue(this string s, long defaultvalue)
        {
            long rzlt = defaultvalue;

            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo culture = CultureInfo.InvariantCulture;
            object o = s;
            if (o != null)
                long.TryParse(o.ToString().Trim().Replace(",", "."), style, culture, out rzlt);

            return rzlt;
        }
        public static int GetIntValue(this string s, int defaultvalue)
        {
            int rzlt = defaultvalue;
            object o = s;
            if (o != null)
                int.TryParse(o.ToString(), out rzlt);

            return rzlt;
        }
        public static short GetShortValue(this string s, short defaultvalue)
        {
            short rzlt = defaultvalue;
            object o = s;
            if (o != null)
                short.TryParse(o.ToString(), out rzlt);

            return rzlt;
        }
        public static byte GetByteValue(this string s, byte defaultvalue)
        {
            byte rzlt = defaultvalue;
            object o = s;
            if (o != null)
                byte.TryParse(o.ToString(), out rzlt);

            return rzlt;
        }
        public static DateTime GetDateValue(this string s, DateTime defaultvalue)
        {
            DateTime rzlt = defaultvalue;
            object o = s;
            if (o != null)
                DateTime.TryParse(o.ToString(), out rzlt);

            return rzlt;
        }
        public static DateTime GetDateValueFromInput(this string s, DateTime defaultvalue)
        {
            string[] spl = s.Trim().Split('-', '/');
            if (spl.Length < 3)
                return defaultvalue;

            DateTime rzlt = defaultvalue;
            rzlt = new DateTime(spl[2].GetIntValue(defaultvalue.Year), spl[1].GetIntValue(defaultvalue.Month), spl[0].GetIntValue(defaultvalue.Day));

            return rzlt;
        }
    }
}
