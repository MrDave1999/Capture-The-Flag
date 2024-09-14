namespace CTF.Application.Players.ClassSelection;

public class ClassSelectionSystem(
    ClassSelectionTextDrawRenderer classSelectionTextDraw,
    TeamTextDrawRenderer teamTextDraw) : ISystem
{
    [Event]
    public void OnPlayerConnect(Player player)
    {
        player.Color = Team.None.ColorHex;
        player.AddComponent<ClassSelectionComponent>();
        player.RemoveAttachedObject(0);
        classSelectionTextDraw.Show(player);
    }

    /// <summary>
    /// This callback is called when a player changes class at class selection (and when class selection first appears).
    /// </summary>
    [Event]
    public void OnPlayerRequestClass(Player player, int classId)
    {
        if (player.HasForcedClassSelectionAfterDeath())
        {
            player.SetSpawnInfo(player.Team, player.Skin, player.Position, player.Angle);
            player.Spawn();
            return;
        }

        player.Color = Team.None.ColorHex;
        player.Position = new Vector3(-1389.137451, 3314.043701, 20.493314);
        player.CameraPosition = new Vector3(-1399.776000, 3310.254150, 21.525623);
        player.SetCameraLookAt(new Vector3(-1395.072143, 3311.873291, 22.027709));
        player.Angle = 111.68f;
        player.Interior = 0;
        player.PlaySound(soundId: 1132);
        Team selectedTeam = classId == (int)TeamId.Alpha ? Team.Alpha : Team.Beta;
        string gameText = selectedTeam.GetAvailabilityMessage();
        player.GameText(gameText, 999999999, 3);
        player.Team = (int)selectedTeam.Id;
    }

    /// <summary>
    /// This callback is called when a player attempts to spawn via class selection either 
    /// by pressing SHIFT or clicking the 'Spawn' button.
    /// </summary>
    [Event]
    public bool OnPlayerRequestSpawn(Player player)
    {
        if (player.IsNotLoggedInOrRegistered())
        {
            player.SendClientMessage(Color.Red, Messages.LoginOrRegisterToContinue);
            return false;
        }
        Team selectedTeam = player.Team == (int)TeamId.Alpha ? Team.Alpha : Team.Beta;
        if (selectedTeam.IsFull())
        {
            string gameText = selectedTeam.GetAvailabilityMessage();
            player.GameText(gameText, 999999999, 3);
            return false;
        }
        player.DisableClassSelection();
        player.GameText("_", 1000, 4);
        player.GetInfo().SetTeam(selectedTeam.Id);
        selectedTeam.Members.Add(player);
        classSelectionTextDraw.Hide(player);
        teamTextDraw.UpdateTeamMembers(selectedTeam);
        return true;
    }

    [Event]
    public void OnPlayerDisconnect(Player player, DisconnectReason reason)
    {
        if (player.IsNotLoggedInOrRegistered())
            return;

        PlayerInfo playerInfo = player.GetInfo();
        if (playerInfo.Team == Team.None)
            return;

        playerInfo.Team.Members.Remove(player);
        teamTextDraw.UpdateTeamMembers(playerInfo.Team);
    }
}
