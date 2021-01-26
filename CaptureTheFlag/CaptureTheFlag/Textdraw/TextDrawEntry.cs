using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CaptureTheFlag.Textdraw
{
    public static class TextDrawEntry
    {
        public static TextDraw TdBoxBlue { get; set; }     
        public static TextDraw TdBarCmds { get; set; }   
        public static TextDraw TdGoat { get; set; }     
        public static TextDraw TdCapture { get; set; }    
        public static TextDraw TdThe { get; set; }         
        public static TextDraw TdFlag { get; set; }         

        public static void Create()
        {
            TdBoxBlue   = new TextDraw();
            TdBarCmds   = new TextDraw();
            TdGoat      = new TextDraw();
            TdCapture   = new TextDraw();
            TdThe       = new TextDraw();
            TdFlag      = new TextDraw();

            TdBoxBlue.Position = new Vector2(319.000000, 430.000000);
            TdBoxBlue.Text = "_";
            TdBoxBlue.Font = TextDrawFont.Normal;
            TdBoxBlue.LetterSize = new Vector2(0.612500, 1.649996);
            TdBoxBlue.Width = 303.000000f;
            TdBoxBlue.Height = 633.000000f;
            TdBoxBlue.Outline = 1;
            TdBoxBlue.Alignment = TextDrawAlignment.Center;
            TdBoxBlue.ForeColor = 65535;
            TdBoxBlue.BackColor = 255;
            TdBoxBlue.BoxColor =  65368;
            TdBoxBlue.UseBox = true;
            TdBoxBlue.Proportional = true;

            TdBarCmds.Position = new Vector2(616.000000, 431.000000);
            TdBarCmds.Text = "~r~/cmds ~y~/help ~p~~h~/admins ~g~/switch ~r~/tc ~y~/stats ~p~~h~/tstats ~g~/users ~w~/weapons";
            TdBarCmds.Font = TextDrawFont.Pricedown;
            TdBarCmds.LetterSize = new Vector2(0.479166, 1.500000);
            TdBarCmds.Outline = 1;
            TdBarCmds.Alignment = TextDrawAlignment.Right;
            TdBarCmds.ForeColor = -1;
            TdBarCmds.BackColor = 255;
            TdBarCmds.Proportional = true;

            TdGoat.Position = new Vector2(26.000000, 335.000000);
            TdGoat.Text = "Preview_Model";
            TdGoat.Font = TextDrawFont.PreviewModel;
            TdGoat.LetterSize = new Vector2(0.600000, 2.000000);
            TdGoat.Width = 138.000000f;
            TdGoat.Height = 90.000000f;
            TdGoat.Outline = 0;
            TdGoat.Alignment = TextDrawAlignment.Left;
            TdGoat.ForeColor = -1;
            TdGoat.BackColor = 0;
            TdGoat.Proportional = true;
            TdGoat.PreviewModel = 6865;
            TdGoat.PreviewRotation = new Vector3(29.000000, 0.000000, 45.000000);
            TdGoat.PreviewZoom = 1.000000f;
            TdGoat.PreviewPrimaryColor = 1;
            TdGoat.PreviewSecondaryColor = 1;

            TdCapture.Position = new Vector2(15.000000, 387.000000);
            TdCapture.Text = "capture";
            TdCapture.Font = TextDrawFont.Pricedown;
            TdCapture.LetterSize = new Vector2(0.487499, 1.799998);
            TdCapture.Outline = 0;
            TdCapture.Shadow = 2;
            TdCapture.Alignment = TextDrawAlignment.Left;
            TdCapture.ForeColor = 16711935;
            TdCapture.BackColor = 255;
            TdCapture.Proportional = true;

            TdThe.Position = new Vector2(83.000000, 358.000000);
            TdThe.Text = "the";
            TdThe.Font = TextDrawFont.Pricedown;
            TdThe.LetterSize = new Vector2(0.487499, 1.799998);
            TdThe.Outline = 0;
            TdThe.Shadow = 2;
            TdThe.Alignment = TextDrawAlignment.Left;
            TdThe.ForeColor = 16711935;
            TdThe.BackColor = 255;
            TdThe.Proportional = true;

            TdFlag.Position = new Vector2(116.000000, 387.000000);
            TdFlag.Text = "flag";
            TdFlag.Font = TextDrawFont.Pricedown;
            TdFlag.LetterSize = new Vector2(0.487499, 1.799998);
            TdFlag.Outline = 0;
            TdFlag.Shadow = 2;
            TdFlag.Alignment = TextDrawAlignment.Left;
            TdFlag.ForeColor = 16711935;
            TdFlag.BackColor = 255;
            TdFlag.Proportional = true;
        }

        public static void Show(Player player)
        {
            TdBoxBlue.Show(player);
            TdBarCmds.Show(player);
            TdGoat.Show(player);
            TdCapture.Show(player);
            TdThe.Show(player);
            TdFlag.Show(player);
        }

        public static void Hide(Player player)
        {
            TdBoxBlue.Hide(player);
            TdBarCmds.Hide(player);
            TdGoat.Hide(player);
            TdCapture.Hide(player);
            TdThe.Hide(player);
            TdFlag.Hide(player);
        }

        public static void Destroy()
        {
            TdBoxBlue.Dispose();
            TdBarCmds.Dispose();
            TdGoat.Dispose();
            TdCapture.Dispose();
            TdThe.Dispose();
            TdFlag.Dispose();
        }
    }
}
