namespace CaptureTheFlag.Utils;

public class Dini
{
    public IniData Data { get; set; }
    public string Section { get; set; }

    public Dini(string filename, string section)
    {
        Section = section;
        Data = new IniDataParser().Parse(File.ReadAllText(Scriptfiles.GetPath(filename)));
    }

    public string Read(string key)
    {
        return Data[Section][key];
    }
}
