using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CaptureTheFlag
{
    public static class ParseData
    {
        public static double Double(string s)
        {
            return double.Parse(s, CultureInfo.InvariantCulture);
        }

        public static float Float(string s)
        {
            return float.Parse(s, CultureInfo.InvariantCulture);
        }
    }
}
