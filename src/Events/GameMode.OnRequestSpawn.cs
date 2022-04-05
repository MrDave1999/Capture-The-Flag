using CaptureTheFlag.Constants;
using CaptureTheFlag.PropertiesPlayer;
using CaptureTheFlag.Textdraw;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;
using CaptureTheFlag.Map;

namespace CaptureTheFlag.Events
{
    public partial class GameMode : BaseMode
    {
        protected override void OnPlayerRequestSpawn(BasePlayer sender, RequestSpawnEventArgs e)
        {
            base.OnPlayerRequestSpawn(sender, e);
            var player = sender as Player;
            if (player.Account == AccountState.Login)
            {
                player.SendClientMessage(Color.Red, "Error: Debes iniciar sesión.");
                e.PreventSpawning = true;
                return;
            }
            if (player.Account == AccountState.Register)
            {
                player.SendClientMessage(Color.Red, "Error: Debes registrarte.");
                e.PreventSpawning = true;
                return;
            }
            if (CurrentMap.IsLoading)
            {
                e.PreventSpawning = true;
                player.SendClientMessage(Color.Red, $"Error: En {CurrentMap.MAX_TIME_LOADING} segundos se cargará el próximo mapa.");
                return;
            }
            if (player.PlayerTeam.GetMessageTeamEnable(out var msg))
            {
                e.PreventSpawning = true;
                player.GameText(msg, 999999999, 3);
                return;
            }
            player.StopAudioStream();
            player.PlayAudioStream("https://dl.dropboxusercontent.com/s/mzt9qnigsh7pdfs/soundtrack.mp3");
            player.IsSelectionClass = false;
            player.GameText("_", 1000, 4);
            Player.Add(player);
            BasePlayer.SendClientMessageToAll($"{player.PlayerTeam.OtherColor}[Team {player.PlayerTeam.NameTeam}]: {player.Name} se añadió al equipo {player.PlayerTeam.NameTeam}.");
            player.SendClientMessage($"{Color.Pink}[!] {Color.White}Captura la bandera del equipo contrario.");
            if (player.PlayerTeam.Id == TeamID.Alpha)
                player.SendClientMessage($"{Color.Pink}[!] {Color.White}Guíate con el {TeamBeta.OtherColor}ícono Azul {Color.White}que aparece en el mapa radar.");
            else
                player.SendClientMessage($"{Color.Pink}[!] {Color.White}Guíate con el {TeamAlpha.OtherColor}ícono Rojo {Color.White}que aparece en el mapa radar.");
            player.SendClientMessage($"{Color.Pink}[!] {Color.White}Luego lleva la bandera a tu base.");
            if (player.PlayerTeam.Flag.PlayerCaptured != null)
                player.SendClientMessage($"{Color.Pink}[!] {Color.White}{player.PlayerTeam.Flag.PlayerCaptured.Name} capturó la bandera de tu equipo, debes recuperarla.");
            TextDrawGlobal.Show(player);
            TextDrawGlobal.UpdateCountUsers();
            TextDrawPlayer.UpdateTdStats(player);
            TextDrawPlayer.UpdateTdRank(player);
            TextDrawPlayer.Show(player);
            TextDrawEntry.Hide(player);
        }
    }
}