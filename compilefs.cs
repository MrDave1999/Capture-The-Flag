using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

class CompileFS
{
	static void Main(string[] args)
	{
		try
		{
			/* 
				The args[0] receives the path where the "scriptfiles" folder is located and thus, 
				the names of the server maps are obtained.
			*/
			string[] fileEntries = Directory.GetFiles(Path.Combine(args[0], "scriptfiles/spawn_position"));
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