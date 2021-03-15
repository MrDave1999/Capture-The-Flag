using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using CaptureTheFlag.PropertiesPlayer;
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
            stats.Text = "";
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

        public static void CreateTDRank(PlayerTextDraw rank)
        {
            rank.Position = new Vector2(607.000000, 402.000000);
            rank.Text = "Noob";
            rank.Font = TextDrawFont.Normal;
            rank.LetterSize = new Vector2(0.337500, 1.249999);
            rank.Outline = 1;
            rank.Alignment = TextDrawAlignment.Right;
            rank.ForeColor = -1;
            rank.BackColor = 255;
            rank.Proportional = true;
        }

        public static void UpdateTdStats(Player player)
        {
            player.Stats.Text = $"~w~KILLS: ~y~{player.Kills}  ~w~DEATHS: ~y~{player.Deaths}  ~w~LVL: ~y~{player.Data.LevelGame}  ~w~SPREE: ~y~{player.Data.KillingSprees}  ~w~ADRENALINE: ~y~{player.Adrenaline}/100";
        }

        public static void UpdateTdRank(Player player)
        {
            player.TdRank.Text = $"{Rank.GetRankLevel(player.Data.LevelGame)}";
        }

        public static void Destroy(Player player)
        {
            player.Stats.Dispose();
            player.THealth.Dispose();
            player.TArmour.Dispose();
            player.TdRank.Dispose();
        }

        public static void Show(Player player)
        {
            player.Stats.Show();
            player.THealth.Show();
            player.TdRank.Show();
        }

        public static void Hide(Player player)
        {
            player.Stats.Hide();
            player.THealth.Hide();
            player.TArmour.Hide();
            player.TdRank.Hide();
        }
    }
}
