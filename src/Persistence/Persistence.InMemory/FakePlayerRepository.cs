﻿namespace Persistence.InMemory;

internal class FakePlayerRepository(
    Dictionary<string, FakePlayer> players,
    IPasswordHasher passwordHasher) : IPlayerRepository
{
    public void Create(PlayerInfo player)
    {
        var passwordHash = passwordHasher.HashPassword(player.Password);
        players.Add(player.Name, new FakePlayer(player.Name, passwordHash));
    }

    public bool Exists(string name)
        => players.TryGetValue(name, out _);

    public PlayerInfo GetOrDefault(EntityId playerId, string name)
    {
        players.TryGetValue(name, out FakePlayer fakePlayer);
        if (fakePlayer is null)
            return default;

        var playerInfo = new PlayerInfo(playerId);
        playerInfo.SetName(fakePlayer.Name);
        // The public setter is used only for plaintext passwords.
        // For that reason, we use Reflection to set the already encrypted password.
        playerInfo.SetValue(value: fakePlayer.PasswordHash, propertyName: nameof(PlayerInfo.Password));
        playerInfo.SetTotalKills(fakePlayer.TotalKills);
        playerInfo.SetTotalDeaths(fakePlayer.TotalDeaths);
        playerInfo.SetMaxKillingSpree(fakePlayer.MaxKillingSpree);
        playerInfo.SetRole(fakePlayer.RoleId);
        playerInfo.SetRank(fakePlayer.RankId);
        playerInfo.SetSkin(fakePlayer.SkinId);
        // Reflection is used here because these properties are immutable.
        // What we did here is what ORMs like EF Core do, so it's nothing new.
        playerInfo.SetValue(value: fakePlayer.BroughtFlags,   propertyName: nameof(PlayerInfo.BroughtFlags));
        playerInfo.SetValue(value: fakePlayer.CapturedFlags,  propertyName: nameof(PlayerInfo.CapturedFlags));
        playerInfo.SetValue(value: fakePlayer.DroppedFlags,   propertyName: nameof(PlayerInfo.DroppedFlags));
        playerInfo.SetValue(value: fakePlayer.ReturnedFlags,  propertyName: nameof(PlayerInfo.ReturnedFlags));
        playerInfo.SetValue(value: fakePlayer.HeadShots,      propertyName: nameof(PlayerInfo.HeadShots));
        playerInfo.SetValue(value: fakePlayer.CreatedAt,      propertyName: nameof(PlayerInfo.CreatedAt));
        playerInfo.SetValue(value: fakePlayer.LastConnection, propertyName: nameof(PlayerInfo.LastConnection));
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
       => players[player.Name].PasswordHash = passwordHasher.HashPassword(player.Password);

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
