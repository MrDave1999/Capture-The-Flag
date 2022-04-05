using SampSharp.GameMode.Display;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Dialogs
{
    public class ListDialogEx : ListDialog
    {
        public IList<int> Ids { get; } = new List<int>();

        public ListDialogEx(string caption, string button1, string button2 = null) 
            : base (caption, button1, button2)
        {
        }

        public void AddItem(int id, string item)
        {
            AddItem(item);
            Ids.Add(id);
        }
    }
}
