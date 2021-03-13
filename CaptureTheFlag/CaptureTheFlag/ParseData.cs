using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CaptureTheFlag
{
    public static class ParseData
    {
        public static double Double(string s) => double.Parse(s, CultureInfo.InvariantCulture);
        public static float Float(string s) => float.Parse(s, CultureInfo.InvariantCulture);
        public static string ToStringDate(DateTime dateTime) => dateTime.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        public static string ToStringDateTime(DateTime dateTime) => dateTime.ToString("yyyy/MM/dd HH:mm:ss tt", CultureInfo.InvariantCulture);
        public static string ToStringTime(DateTime dateTime) => dateTime.ToString("HH:mm:ss tt", CultureInfo.InvariantCulture);
    }
}
