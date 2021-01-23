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
                    CmdPublic.TeamChat(player, text);
                    break;
                case '$': //VipChat
                    CmdVip.VipChat(player, text);
                    break;
                case '#': //AdminChat
                    CmdAdmin.AdminChat(player, text);
                    break;
                default:
                    AlterString(text, symbol);
                    if(player.Data.LevelAdmin >= 1)
                        BasePlayer.SendClientMessageToAll($"{player.Color}{player.Name} {{00FF00}}[{player.Id}]: {Color.White}{text}");
                    else if(player.Data.LevelVip >= 1)
                        BasePlayer.SendClientMessageToAll($"{player.Color}{player.Name} {Color.Yellow}[{player.Id}]: {Color.White}{text}");
                    else
                        BasePlayer.SendClientMessageToAll($"{player.Color}{player.Name} {Color.White}[{player.Id}]: {text}");
                    break;
            }
        }

    }
}
