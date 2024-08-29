namespace Persistence.InMemory;

internal class FakePlayerRepository(Dictionary<string, FakePlayer> players) : IPlayerRepository
{
    public void Create(PlayerInfo player)
        => players.Add(player.Name, new FakePlayer(player.Name, player.Password));

    public bool Exists(string name)
        => players.TryGetValue(name, out _);

    public PlayerInfo GetOrDefault(EntityId playerId, string name)
    {
        players.TryGetValue(name, out FakePlayer fakePlayer);
        if (fakePlayer is null)
            return default;

        var playerInfo = new PlayerInfo(playerId);
        playerInfo.SetName(fakePlayer.Name);
        playerInfo.SetPassword(fakePlayer.Password);
        playerInfo.SetTotalKills(fakePlayer.TotalKills);
        playerInfo.SetTotalDeaths(fakePlayer.TotalDeaths);
        playerInfo.SetMaxKillingSpree(fakePlayer.MaxKillingSpree);
        playerInfo.SetRole(fakePlayer.RoleId);
        playerInfo.SetRank(fakePlayer.RankId);
        playerInfo.SetSkin(fakePlayer.SkinId);
        playerInfo.SetValue(fakePlayer.BroughtFlags,   propertyName: nameof(PlayerInfo.BroughtFlags));
        playerInfo.SetValue(fakePlayer.CapturedFlags,  propertyName: nameof(PlayerInfo.CapturedFlags));
        playerInfo.SetValue(fakePlayer.DroppedFlags,   propertyName: nameof(PlayerInfo.DroppedFlags));
        playerInfo.SetValue(fakePlayer.ReturnedFlags,  propertyName: nameof(PlayerInfo.ReturnedFlags));
        playerInfo.SetValue(fakePlayer.HeadShots,      propertyName: nameof(PlayerInfo.HeadShots));
        playerInfo.SetValue(fakePlayer.CreatedAt,      propertyName: nameof(PlayerInfo.CreatedAt));
        playerInfo.SetValue(fakePlayer.LastConnection, propertyName: nameof(PlayerInfo.LastConnection));
        return playerInfo;
    }

    public void UpdateBroughtFlags(PlayerInfo player) 
        => players[player.Name].BroughtFlags = player.BroughtFlags;

    public void UpdateCapturedFlags(PlayerInfo player)
        => players[player.Name].CapturedFlags = player.CapturedFlags;

    public void UpdateDroppedFlags(PlayerInfo player)
        => players[player.Name].DroppedFlags = player.DroppedFlags;

    public void UpdateReturnedFlags(PlayerInfo player)
        => players[player.Name].ReturnedFlags = player.ReturnedFlags;

    public void UpdateHeadShots(PlayerInfo player)
        => players[player.Name].HeadShots = player.HeadShots;

    public void UpdateLastConnection(PlayerInfo player)
        => players[player.Name].LastConnection = player.LastConnection;

    public void UpdateMaxKillingSpree(PlayerInfo player)
        => players[player.Name].MaxKillingSpree = player.MaxKillingSpree;

    public void UpdateName(PlayerInfo player)
        => players[player.Name].Name = player.Name;

    public void UpdatePassword(PlayerInfo player)
        => players[player.Name].Password = player.Password;

    public void UpdateRank(PlayerInfo player)
        => players[player.Name].RankId = player.RankId;

    public void UpdateRole(PlayerInfo player)
        => players[player.Name].RoleId = player.RoleId;

    public void UpdateSkin(PlayerInfo player)
        => players[player.Name].SkinId = player.SkinId;

    public void UpdateTotalDeaths(PlayerInfo player)
        => players[player.Name].TotalDeaths = player.TotalDeaths;

    public void UpdateTotalKills(PlayerInfo player)
        => players[player.Name].TotalKills = player.TotalKills;
}
