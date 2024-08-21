namespace CTF.Application.Players.Accounts;

public class AccountComponent : Component
{
    public PlayerInfo PlayerInfo { get; }
    public AccountComponent(PlayerInfo player)
    {
        ArgumentNullException.ThrowIfNull(player);
        PlayerInfo = player;
    }
}
