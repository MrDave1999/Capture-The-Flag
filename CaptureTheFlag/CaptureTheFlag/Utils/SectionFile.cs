using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CaptureTheFlag.Utils
{
    public class SectionFile
    {
        public Dictionary<string, List<string>> Data { get; private set; }

        public SectionFile(string filename)
        {
            Data = new Dictionary<string, List<string>>();
            var lines = File.ReadAllLines(Scriptfiles.GetPath(filename));
            List<string> values = null;
            int len = lines.Length;
            for (int initial = 0; initial < len; ++initial)
            {
                if (lines[initial][0] == '[')
                {
                    var section = lines[initial][1..^1];
                    values = new List<string>();
                    Data.Add(section, values);
                }
                else
                    values?.Add(lines[initial]);
            }
        }

        public List<string> GetContentSection(string section)
        {
            Data.TryGetValue(section, out List<string> value);
            return value;
        }
    }
}
