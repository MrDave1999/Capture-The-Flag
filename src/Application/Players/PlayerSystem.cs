namespace CTF.Application.Players;

public class PlayerSystem : ISystem
{
    [Event]
    public bool OnPlayerRequestSpawn(Player player)
    {
        var accountComponent = player.GetComponent<AccountComponent>();
        if (accountComponent is null)
        {
            player.SendClientMessage(Color.Red, Messages.LoginOrRegisterToContinue);
            return false;
        }

        return true;
    }
}
