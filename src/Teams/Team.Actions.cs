namespace CaptureTheFlag.Teams;

public partial class Team
{
    public void Captured(Player player, bool takeInPosBase = true)
    {
        Flag.IsPositionBase = false;
        Flag.AttachedObject(player);
        Flag.PlayerCaptured = player;
        player.JumpTime = 0;
        if (player.IsEnableSpeed())
        {
            player.SpeedTime = 0;
            player.ClearAnimations();
        }
        if (player.IsEnableInvisible())
        {
            player.InvisibleTime = 0;
            player.DisableInvisibility();
        }
        if (player.IsInvisible)
        {
            player.DisableInvisibility();
            player.IsInvisible = false;
        }
        if (takeInPosBase)
        {
            PickupInfo = Pickup.Create(1239, 1, Flag.PositionBase);
            PickupInfo.PickUp += OnPickUp;
            BasePlayer.SendClientMessageToAll($"{OtherColor}[Team {NameTeam}]: {player.Name} capturó la bandera {NameColor} del equipo {NameTeam}.");
            player.SendClientMessage($"{Color.Pink}[!]: {Color.White}Capturaste la bandera, debes llevarla a tu base.");
            player.UpdateAdrenaline(4, "capturar la bandera");
            BasePlayer.GameTextForAll($"~n~~n~~n~{ColorGameText}la bandera {NameColor} fue capturada!", 5000, 3);
        }
        else
        {
            BasePlayer.SendClientMessageToAll($"{OtherColor}[Team {NameTeam}]: {player.Name} tomó la bandera {NameColor} del equipo {NameTeam}.");
            player.SendClientMessage($"{Color.Pink}[!]: {Color.White}Debes llevar esa bandera a tu base.");
            BasePlayer.GameTextForAll($"~n~~n~~n~{ColorGameText}la bandera {NameColor} fue tomada!", 5000, 3);
            Timer.Stop();

        }
        player.GameText($"~n~~n~~n~{ColorGameText}lleva la bandera {NameColor} a tu base!", 5000, 3);
    }

    public void Carry(Player player)
    {
        BasePlayer.SendClientMessageToAll($"{OtherColor}[Team {NameTeam}]: {player.Name} llevó la bandera {NameColor} del equipo {NameTeam} a su base.");
        BasePlayer.GameTextForAll($"~n~~n~~n~{TeamRival.ColorGameText}+1 score team {TeamRival.NameTeam}", 5000, 3);
        player.RemoveAttachedObject(0);
        Flag.Create();
        PickupInfo.Dispose();
        Flag.PlayerCaptured = null;
        Flag.IsPositionBase = true;
        ++TeamRival.Score;
        TeamRival.UpdateTdScore();
        player.UpdateAdrenaline(10, "llevar la bandera tu base");
        player.UpdateData("droppedFlags", ++player.Data.DroppedFlags);
        foreach (Player player1 in player.PlayerTeam.Players)
            if (player != player1)
                player1.UpdateAdrenaline(3, "ayudar a capturar la bandera");
    }

    public void Recover(Player player)
    {
        Flag.IsPositionBase = true;
        Flag.Create();
        PickupInfo.Dispose();
        BasePlayer.SendClientMessageToAll($"{OtherColor}[Team {NameTeam}]: {player.Name} recuperó la bandera {NameColor} del equipo {NameTeam}.");
        BasePlayer.GameTextForAll($"~n~~n~~n~{ColorGameText}la bandera {NameColor} fue recuperada!", 5000, 3);
        player.UpdateAdrenaline(4, "recuperar la bandera");
        Timer.Stop();
    }

    public void Drop(Player player, Player killer)
    {
        Drop(player);
        if (killer != null)
            killer.UpdateAdrenaline(4, "matar al portador");
    }

    public void Drop(Player player)
    {
        Flag.Create(player);
        Flag.PlayerCaptured = null;
        Flag.IsPositionBase = false;
        BasePlayer.SendClientMessageToAll($"{OtherColor}[Team {NameTeam}]: {player.Name} dejó caer la bandera {NameColor} del equipo {NameTeam}.");
        BasePlayer.GameTextForAll($"~n~~n~~n~{ColorGameText}la bandera {NameColor} fue soltada!", 5000, 3);
        player.RemoveAttachedObject(0);
        Timer.Start();
    }
}
