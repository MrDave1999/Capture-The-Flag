using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;

namespace CaptureTheFlag.Textdraw
{
    public static class TextDrawPlayer
    {
        public static void CreateTDStats(PlayerTextDraw stats)
        {
            stats.Position = new Vector2(638.000000, 433.000000);
            stats.Text = "~g~~h~] ~w~KILLS: ~y~0 ~g~~h~- ~w~DEATHS: ~y~0 ~g~~h~- ~w~LVL: ~y~0 ~g~~h~- ~w~ADRENALINE: ~y~0/100~g~~h~ ]";
            stats.Font = TextDrawFont.Slim;
            stats.LetterSize = new Vector2(0.279166, 1.350000);
            stats.Outline = 1;
            stats.Alignment = TextDrawAlignment.Right;
            stats.ForeColor = -1;
            stats.BackColor= 255;
            stats.Proportional = true;
        }

        public static void UpdateTdStats(Player player)
        {
            player.Stats.Text = $"~g~~h~] ~w~KILLS: ~y~{player.Kills} ~g~~h~- ~w~DEATHS: ~y~{player.Deaths} ~g~~h~- ~w~LVL: ~y~{player.Data.LevelGame} ~g~~h~- ~w~ADRENALINE: ~y~{player.Adrenaline}/100~g~~h~ ]";
            player.Stats.Show();
        }

        public static void Destroy(Player player)
        {
            player.Stats.Dispose();
        }

        public static void Show(Player player)
        {
            player.Stats.Show();
        }

        public static void Hide(Player player)
        {
            player.Stats.Hide();
        }

    }
}
