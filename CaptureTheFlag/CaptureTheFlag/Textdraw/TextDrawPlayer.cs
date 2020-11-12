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

        public static void CreateTDHealth(PlayerTextDraw health)
        {
            health.Position = new Vector2(578.000000, 66.000000);
            health.Text = "100";
            health.Font = TextDrawFont.Slim;
            health.LetterSize = new Vector2(0.241666, 0.899999);
            health.Outline = 1;
            health.Alignment = TextDrawAlignment.Center;
            health.ForeColor = -1;
            health.BackColor = 255;
            health.Proportional = true;
        }

        public static void CreateTDArmour(PlayerTextDraw armour)
        {
            armour.Position = new Vector2(578.000000, 44.000000);
            armour.Text = "0";
            armour.Font = TextDrawFont.Slim;
            armour.LetterSize = new Vector2(0.241666, 0.899999);
            armour.Outline = 1;
            armour.Alignment = TextDrawAlignment.Center;
            armour.ForeColor = -1;
            armour.BackColor = 255;
            armour.Proportional = true;
        }

        public static void UpdateTdStats(Player player)
        {
            player.Stats.Text = $"~g~~h~] ~w~KILLS: ~y~{player.Kills} ~g~~h~- ~w~DEATHS: ~y~{player.Deaths} ~g~~h~- ~w~LVL: ~y~{player.Data.LevelGame} ~g~~h~- ~w~ADRENALINE: ~y~{player.Adrenaline}/100~g~~h~ ]";
            player.Stats.Show();
        }

        public static void Destroy(Player player)
        {
            player.Stats.Dispose();
            player.THealth.Dispose();
            player.TArmour.Dispose();
        }

        public static void Show(Player player)
        {
            player.Stats.Show();
            player.THealth.Show();
        }

        public static void Hide(Player player)
        {
            player.Stats.Hide();
            player.THealth.Hide();
            player.TArmour.Hide();
        }

    }
}
