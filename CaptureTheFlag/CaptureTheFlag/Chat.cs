using CaptureTheFlag.Command;
using CaptureTheFlag.Command.Admin;
using CaptureTheFlag.Command.Public;
using CaptureTheFlag.Command.Vip;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;


namespace CaptureTheFlag
{
    public class Chat
    {
        public static void AlterString(string text, char c)
        {
            unsafe
            {
                fixed (char* str = text)
                    str[0] = c;
            }
        }

        public static void WriteText(Player player, string text)
        {
            char symbol = text[0];
            AlterString(text, ' ');
            switch (symbol)
            {
                case '!': //TeamChat
                    if (player.Team != BasePlayer.NoTeam)
                    {
                        CmdPublic.TeamChat(player, text);
                        return;
                    }
                    break;
                case '$': //VipChat
                    if (player.Data.LevelVip > 0)
                    {
                        CmdVip.VipChat(player, text);
                        return;
                    }
                    break;
                case '#': //AdminChat
                    if (player.Data.LevelAdmin > 0)
                    {
                        CmdAdmin.AdminChat(player, text);
                        return;
                    }
                    break;
                case '&': //Asay
                    if(player.Data.LevelAdmin > 0)
                    {
                        CmdAdmin.Asay(player, text);
                        return;
                    }
                    break;
                case '@': //Vsay
                    if(player.Data.LevelVip > 0)
                    {
                        CmdVip.Vsay(player, text);
                        return;
                    }
                    break;
                case '~': //Nsay
                    if(player.Data.LevelVip >= 2)
                    {
                        CmdVip.Nsay(player, text);
                        return;
                    }
                    break;
            }
            AlterString(text, symbol);
            if (player.Data.LevelAdmin >= 1)
                BasePlayer.SendClientMessageToAll($"{player.Color}{player.Name} {{00FF00}}[{player.Id}]: {Color.White}{text}");
            else if (player.Data.LevelVip >= 1)
                BasePlayer.SendClientMessageToAll($"{player.Color}{player.Name} {Color.Yellow}[{player.Id}]: {Color.White}{text}");
            else
                BasePlayer.SendClientMessageToAll($"{player.Color}{player.Name} {Color.White}[{player.Id}]: {text}");
        }
    }
}
