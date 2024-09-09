﻿namespace CTF.Application.Players;

public class PlayerSpawnSystem(MapInfoService mapInfoService) : ISystem
{
    private readonly CurrentMap _currentMap = mapInfoService.Read();

    [Event]
    public bool OnPlayerRequestSpawn(Player player)
    {
        var accountComponent = player.GetComponent<AccountComponent>();
        bool isNotLoggedInOrRegistered = accountComponent is null;
        if (isNotLoggedInOrRegistered)
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
        player.GetComponent<ClassSelectionComponent>().IsInClassSelection = false;
        player.GameText("_", 1000, 4);
        PlayerInfo playerInfo = accountComponent.PlayerInfo;
        playerInfo.SetTeam((TeamId)player.Team);
        return true;
    }

    [Event]
    public void OnPlayerSpawn(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        SpawnLocation spawnLocation = _currentMap.GetRandomSpawnLocation(playerInfo.Team.Id);
        player.Position = spawnLocation.Position;
        player.Angle = spawnLocation.Angle;
        player.Interior = _currentMap.Interior;
        player.Color = playerInfo.Team.ColorHex;
        if (playerInfo.HasSkin())
        {
            player.Skin = playerInfo.SkinId;
        }
    }
}
