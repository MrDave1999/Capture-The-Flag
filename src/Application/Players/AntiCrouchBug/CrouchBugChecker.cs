namespace CTF.Application.Players.AntiCrouchBug;

public class CrouchBugChecker(UnixTimeSeconds unixTimeSeconds) : ISystem
{
    [Event]
    public void OnPlayerConnect(Player player)
    {
        player.AddComponent<LastFiredTimeComponent>();
    }

    [Event]
    public void OnPlayerKeyStateChange(Player player, Keys newKeys, Keys oldKeys)
    {
        if (player.State != PlayerState.OnFoot)
            return;

        var lastFiredTimeComponent = player.GetComponent<LastFiredTimeComponent>();
        if (player.SpecialAction != SpecialAction.Duck && 
            KeyUtils.HasPressed(newKeys, oldKeys, Keys.Fire))
        {
            lastFiredTimeComponent.Value = player.Weapon switch
            {
                Weapon.Deagle => unixTimeSeconds.Value,
                _ => default
            };
        }
        else if (KeyUtils.HasPressed(newKeys, oldKeys, Keys.Crouch))
        {
            long currentTime = unixTimeSeconds.Value;
            long elapsedTime = currentTime - lastFiredTimeComponent.Value;
            if (elapsedTime < 1)
            {
                player.GameText("~r~~h~DON'T C-BUG!", 3000, 4);
                player.ApplyAnimation(
                    animationLibrary: "PED", 
                    animationName: "getup", 
                    fDelta: 4.1f, 
                    loop: false, 
                    lockX: false, 
                    lockY: false, 
                    freeze: false, 
                    time: 0, 
                    forceSync: false
                );
            }
        }
    }
}
