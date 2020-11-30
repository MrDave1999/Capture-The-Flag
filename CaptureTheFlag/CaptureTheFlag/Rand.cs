using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    public static class Rand
    {
        private static readonly Random random = new Random();

        public static int Next(int max)
        {
            return random.Next(max);
        }

    }
}
