using SampSharp.Core.Natives.NativeObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
	public class TimeNative : NativeObjectSingleton<TimeNative>
    {
		[NativeMethod]
		public virtual int gettime(int hour = 0, int minute = 0, int second = 0)
		{
			throw new NativeNotImplementedException();
		}
	}

	public class Time
    {

		public static int GetTime()
        {
			return TimeNative.Instance.gettime(); 
		}

		/* Displays the time in MM:SS format. */
		public static string Show(int time)
        {
			int dif = time - GetTime();
			return $"{dif / 60:D2}:{dif % 60:D2}";
		}
	}
}
