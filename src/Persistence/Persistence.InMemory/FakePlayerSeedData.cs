namespace Persistence.InMemory;

internal static class FakePlayerSeedData
{
    /// <summary>
    /// Password Text: 123456
    /// This password is for test purposes only.
    /// </summary>
    private const string Password = "$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW";
    public static Dictionary<int, FakePlayer> Create()
    {
        FakePlayer[] players =
        [
            new()
            {
                Name = "Admin_Player",
                PasswordHash = Password,
                RoleId = RoleId.Admin,
                RankId = RankId.Noob,
                SkinId = 146
            },
            new()
            {
                Name = "Moderator_Player",
                PasswordHash = Password,
                RoleId = RoleId.Moderator,
                RankId = RankId.Noob,
                SkinId = 146
            },
            new()
            {
                Name = "VIP_Player",
                PasswordHash = Password,
                RoleId = RoleId.VIP,
                RankId = RankId.Noob,
                SkinId = 146
            },
            new()
            {
                Name = "Basic_Player",
                PasswordHash = Password,
                RoleId = RoleId.Basic,
                RankId = RankId.Noob,
                SkinId = 146
            },
            new()
            {
                Name = "Basic_Player(2)",
                PasswordHash = Password,
                RoleId = RoleId.Basic,
                RankId = RankId.SemiAdvance,
                TotalKills = 150,
                MaxKillingSpree = 10,
                SkinId = 131
            },
            new()
            {
                Name = "Basic_Player(3)",
                PasswordHash = Password,
                RoleId = RoleId.Basic,
                RankId = RankId.SemiAdvance,
                TotalKills = 160,
                MaxKillingSpree = 15,
                SkinId = 140
            },
            new()
            {
                Name = "Basic_Player(4)",
                PasswordHash = Password,
                RoleId = RoleId.Basic,
                RankId = RankId.SemiAdvance,
                TotalKills = 170,
                MaxKillingSpree = 20,
                SkinId = 137
            },
            new()
            {
                Name = "Basic_Player(5)",
                PasswordHash = Password,
                RoleId = RoleId.Basic,
                RankId = RankId.Advanced,
                TotalKills = 200,
                MaxKillingSpree = 25,
                SkinId = 100
            },
            new()
            {
                Name = "Basic_Player(6)",
                PasswordHash = Password,
                RoleId = RoleId.Basic,
                RankId = RankId.Hitman,
                TotalKills = 251,
                MaxKillingSpree = 50,
                SkinId = 98
            },
            new()
            {
                Name = "Basic_Player(7)",
                PasswordHash = Password,
                RoleId = RoleId.Basic,
                RankId = RankId.Advanced,
                TotalKills = 200,
                MaxKillingSpree = 30,
                SkinId = 150
            }
        ];
        return players.ToDictionary(player => player.Id, player => player);
    }
}
