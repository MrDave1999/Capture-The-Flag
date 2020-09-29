using SampSharp.GameMode;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    public class Team
    {
        public TeamID Id { get; set; }
        public int Members { get; set; }
        public int Score { get; set; }
        public int Skin { get; set; }
        public string NameTeam { get; set; }
        public string NameColor { get; set; }
        public string ColorGameText { get; set; }
        public string OtherColor { get; set; }
        public Flag Flag { get; set; }
        public Team TeamRival { get; set; }
        public TextDraw TdScore { get; set; }

        public Team(int skin, string otherColor, string colorGameText, TextDraw tdscore, TeamID teamid, string name, string namecolor, Flag flag)
        {
            Skin = skin;
            OtherColor = otherColor;
            ColorGameText = colorGameText;
            TdScore = tdscore;
            Id = teamid;
            NameTeam = name;
            NameColor = namecolor;
            Flag = flag;
        }

        public bool IsFull()
        {
            return Members > TeamRival.Members;
        }

        public void UpdateTdScore()
        {
            TdScore.Text = $"{ColorGameText}{NameTeam}: {Score}";
            TdScore.Show();
        }
        
        public bool GetMessageTeamEnable(out string message, bool msgComplete = true)
        {
            bool full;
            message = (full = IsFull()) ?
                (msgComplete ? $"~y~{NameTeam}~n~~r~ not available" : "not available") :
                (msgComplete ? $"~y~{NameTeam}~n~~r~ available" : "available");
            return full;
        }

        public void ExecuteAction(Player player, Pickup pickup)
        {
            if (Flag.IsPositionBase)
            {
                if (player.PlayerTeam.Id == TeamRival.Id)
                {
                    Captured(player);
                    pickup.Dispose();
                }
                else if (player == TeamRival.Flag.PlayerCaptured)
                    TeamRival.Carry(player);
            }
            else
            {
                if (player.PlayerTeam.Id == Id)
                    Recover(player);
                else
                    Captured(player, false);
                pickup.Dispose();
            }
        }

        public void Captured(Player player, bool takeInPosBase = true)
        {
            Flag.IsPositionBase = false;
            Flag.AttachedObject(player);
            Flag.PlayerCaptured = player;
            if (takeInPosBase)
            {
                BasePlayer.SendClientMessageToAll(Color.Yellow, $"[CTF]: {player.Name} ha capturado la bandera {NameColor} del equipo {NameTeam}.");
                player.SendClientMessage(Color.LimeGreen, "[CTF]: Capturaste la bandera, debes llevarla a tu base!");
                player.SendClientMessage(Color.LimeGreen, "[CTF]: Obtuviste +6 de score por capturar la bandera.");
                player.Score += 6;
            }
            else
            {
                BasePlayer.SendClientMessageToAll(Color.Yellow, $"[CTF]: {player.Name} ha tomado la bandera {NameColor} del equipo {NameTeam}.");
                player.SendClientMessage(Color.LimeGreen, "[CTF]: Debes llevar esa bandera a tu base, apura!");
            }
        }

        public void Carry(Player player)
        {
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"[CTF]: {player.Name} ha llevado la bandera {NameColor} del equipo {NameTeam} a su base.");
            player.SendClientMessage(Color.LimeGreen, "[CTF]: Obtuviste +10 de score por llevar la bandera a tu base.");
            BasePlayer.GameTextForAll($"~>~{TeamRival.ColorGameText}+1 score team {TeamRival.NameTeam}!", 5000, 5);
            player.RemoveAttachedObject(0);
            Flag.Create(); 
            Flag.PlayerCaptured = null;
            Flag.IsPositionBase = true;
            TeamRival.Score++;
            TeamRival.UpdateTdScore();
            player.Score += 10;
        }

        public void Recover(Player player)
        {
            Flag.IsPositionBase = true;
            Flag.Create();
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"[CTF]: {player.Name} ha recuperado la bandera {NameColor} del equipo {NameTeam}.");
            player.SendClientMessage(Color.LimeGreen, "[CTF]: Obtuviste +4 de score por recuperar la bandera.");
            player.Score += 4;
        }

        public void Drop(Player player, Player killer)
        {
            Drop(player);
            killer.SendClientMessage(Color.LimeGreen, "[CTF]: Obtuviste +4 de score por matar al portador.");
            killer.Score += 4;
        }

        public void Drop(Player player)
        {
            Flag.Create(player);
            Flag.PlayerCaptured = null;
            Flag.IsPositionBase = false;
            BasePlayer.SendClientMessageToAll(Color.Yellow, $"[CTF]: La bandera {NameColor} del equipo {NameTeam} fue soltada por {player.Name}.");
        }
    }

    public enum TeamID
    {
       None,
       Alpha,
       Beta
    }

    public class SkinTeam
    {
        public static int Alpha { get; } = 170;
        public static int Beta { get; } = 177;
    }
}
