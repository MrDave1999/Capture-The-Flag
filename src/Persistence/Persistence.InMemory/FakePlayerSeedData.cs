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
            }
        ];
        return players.ToDictionary(player => player.Id, player => player);
    }
}
