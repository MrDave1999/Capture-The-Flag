namespace CTF.Application.Players.Accounts;

internal class AccountComponent : Component
{
    public PlayerInfo PlayerInfo { get; }
    public AccountStatus Status { get; }
    public AccountComponent(PlayerInfo player, AccountStatus status)
    {
        PlayerInfo = player;
        Status = status;
    }
}
