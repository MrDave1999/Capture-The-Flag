using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Data
{
    public class Colors
    {
        private static string[] admins = new[]
        {
            "{FFFF00}", 
            "{00FFFF}", 
            "{FF0000}", 
            "{FF00FF}", 
        };

        private static string[] vips = new[]
        {
            "{FF8A33}",
            "{22C87F}",
            "{C8A522}"
        };

        public static string GetColorAdmin(int levelid) => admins[levelid - 1];
        public static string GetColorVip(int levelid) => vips[levelid - 1];
    }
}
