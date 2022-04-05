using SampSharp.Core.Natives.NativeObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Utils
{
	public class TimeNative : NativeObjectSingleton<TimeNative>
    {
		[NativeMethod]
		public virtual int gettime(int hour = 0, int minute = 0, int second = 0)
			=> throw new NativeNotImplementedException();
	}

	public class Time
    {
		public static int GetTime() => TimeNative.Instance.gettime(); 

		/* Displays the time in HH:MM:SS format. */
		public static string Show(int time)
        {
			int dif = time - GetTime();
			dif = (dif > 0) ? dif : -dif;
			string hour = $"{dif / 3600:D2}";
			string minutes = $"{(dif / 60) % 60:D2}";
			string seconds = $"{dif % 60:D2}";
			return ((dif / 3600) > 0) ? $"{hour}:{minutes}:{seconds}": $"{minutes}:{seconds}";
		}
	}
}
