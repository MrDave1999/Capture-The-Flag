using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    public class Time
    {
		private static readonly DateTime dt = new DateTime(1970, 1, 1);

		/* Code by Tim Rogers (https://stackoverflow.com/a/8134182) */
		public static double GetTime()
		{
			return (DateTime.Now - dt).TotalMilliseconds;
		}

		/* Displays the time in MM:SS format. */
		public static string Show(double time)
        {
			int dif = ((int)(time - GetTime())) / 1000;
			return $"{dif / 60:D2}:{dif % 60:D2}";
		}
	}
}
