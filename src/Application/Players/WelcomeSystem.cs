namespace CTF.Application.Players;

public class WelcomeSystem : ISystem
{
    [Event]
    public void OnPlayerConnect(Player player)
    {
        player.SendClientMessage(Color.Yellow, Messages.Welcome1);
        player.SendClientMessage(Color.Red, Messages.Welcome2);
        player.SendClientMessage(Color.Yellow, Messages.Welcome3);
    }
}
