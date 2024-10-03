namespace CTF.Application.Players.Accounts;

public class AccountComponent : Component
{
    public PlayerInfo PlayerInfo { get; }
    public bool IsAuthenticated { get; }
    public bool IsUnauthenticated => !IsAuthenticated;
    public AccountComponent(PlayerInfo playerInfo, bool isAuthenticated)
    {
        ArgumentNullException.ThrowIfNull(playerInfo);
        PlayerInfo = playerInfo;
        IsAuthenticated = isAuthenticated;
    }
}
