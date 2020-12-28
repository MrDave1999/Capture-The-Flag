using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

class CompileFS
{
	static void Main(string[] arg)
	{
		try
		{
			string[] fileEntries = Directory.GetFiles("scriptfiles/spawn_position");
			using (Process myProcess = new Process())
            {
				myProcess.StartInfo.FileName = "cmd.exe";
				foreach(string file in fileEntries)
				{
					myProcess.StartInfo.Arguments = "/c cd filterscripts & pawncc " + Path.GetFileName(file).Replace(".txt", "") + ".pwn";
					myProcess.Start();
				}
            }
		}
        catch (Exception e)
        {
			Console.WriteLine("Error: " + e.Message);
        }
	}
}