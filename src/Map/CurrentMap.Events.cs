namespace CaptureTheFlag.Map;

public partial class CurrentMap
{
    /* When the new map is loading.. */
    public static void OnLoadingMap()
    {
        IsLoading = true;
        if (TeamAlpha.Score > TeamBeta.Score)
            SendClientMessageToAll(Color.Red, $"[Round]: {Color.Yellow}Esta partida la ganó el equipo Alpha.");
        else if (TeamAlpha.Score == TeamBeta.Score)
            SendClientMessageToAll(Color.Red, $"[Round]: {Color.Yellow}Hubo un empate! Ningún equipo ganó.");
        else
            SendClientMessageToAll(Color.Red, $"[Round]: {Color.Yellow}Esta partida la ganó el equipo Beta.");

        Server.SendRconCommand($"unloadfs {GetMapName(Id)}");
        /*
            This verifies if any player has actually forced the map change. 
            Therefore, the sequence for the "map change" is not followed.
        */
        Id = (ForceMap == -1) ? GetNextMapId() : ForceMap;
        foreach (Player player in Player.GetAll())
            player.ToggleControllable(false);

        SendClientMessageToAll(Color.Yellow, $"** En {MAX_TIME_LOADING} segundos se cargará el próximo mapa: {Color.Red}{GetMapName(Id)}");
        Flag.RemoveAll();
        TeamAlpha.Flag.DeletePlayerCaptured();
        TeamBeta.Flag.DeletePlayerCaptured();
        LoadMapData();
        TeamAlpha.Flag.Create(LoadFlagPosition("Red"));
        TeamBeta.Flag.Create(LoadFlagPosition("Blue"));
        TeamAlpha.UpdateIcon();
        TeamBeta.UpdateIcon();
        TeamAlpha.Timer.Stop();
        TeamBeta.Timer.Stop();
        Server.SendRconCommand($"loadfs {GetMapName(Id)}");
        Server.SendRconCommand($"mapname {GetMapName(Id)}");
    }

    /* When the new map is loaded.. */
    public static void OnLoadedMap()
    {
        GameTextForAll("_", 1000, 4);
        IsLoading = false;
        ForceMap = -1;
        SendClientMessageToAll(Color.Yellow, "** El mapa se cargó con éxito!");
        foreach (Player player in BasePlayer.GetAll<Player>())
        {
            if (player.IsConnected)
            {
                player.Kills = 0;
                player.Deaths = 0;
                player.KillingSprees = 0;
                player.Adrenaline = 0;
                if (player.Data.LevelVip == 3)
                    player.Adrenaline = 100;
                if (player.Team != NoTeam)
                {
                    player.ToggleControllable(true);
                    player.SetForceClass();
                }
                player.Team = NoTeam;
                player.Color = ColorWhite;
            }
        }
        TeamAlpha.Players.Clear();
        TeamBeta.Players.Clear();
        TextDrawGlobal.UpdateCountUsers();
        TeamAlpha.ResetStats();
        TeamBeta.ResetStats();
        timeLeft = MAX_TIME_ROUND;
        Server.SetWeather(Weather);
        Server.SetWorldTime(WorldTime);
    }

    /* When the map change is confirmed, this occurs if the player wishes to force the map change later or immediately.. */
    public static void OnConfirmMapChange(int mapId, DialogResponseEventArgs e)
    {
        var player = e.Player as Player;
        if (IsLoading)
        {
            player.SendClientMessage(Color.Red, $"Error: El mapa {GetCurrentMap()} se está cargando. ");
            return;
        }
        if (e.DialogButton == DialogButton.Left)
        {
            timeLeft = 5;
            SendClientMessageToAll(Color.Red, $"[Change Map]: {Color.Yellow}{player.Name} forzó el cambio de mapa a: {Color.Red}{GetMapName(mapId)}.");
        }
        else
            SendClientMessageToAll(Color.Red, $"[Next Map]: {Color.Yellow}{player.Name} decidió que el próximo mapa será en: {Color.Red}{GetMapName(mapId)}.");
        ForceMap = mapId;
    }
}
