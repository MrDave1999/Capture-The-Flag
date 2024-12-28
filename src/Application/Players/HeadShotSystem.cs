namespace CTF.Application.Players;

public class HeadShotSystem(
    IPlayerRepository playerRepository,
    IWorldService worldService) : ISystem
{
    /// <summary>
    /// This callback is called when a player takes damage.
    /// </summary>
    /// <param name="player">
    /// The player that took damage.
    /// </param>
    /// <param name="issuer">
    /// The player that caused the damage. <c>null</c> if self-inflicted.
    /// </param>
    /// <param name="amount">
    /// The amount of damage the player took (health and armour combined).
    /// </param>
    /// <param name="weapon">
    /// The ID of the weapon/reason for the damage.
    /// </param>
    /// <param name="bodyPart">
    /// The <see href="https://www.open.mp/docs/scripting/resources/bodyparts">body part</see> that was hit.
    /// </param>
    [Event]
    public void OnPlayerTakeDamage(Player player, Player issuer, float amount, Weapon weapon, BodyPart bodyPart)
    {
        if (issuer.IsInvalidPlayer())
            return;

        if ((weapon >= Weapon.None && weapon <= Weapon.Cane) || (weapon >= Weapon.Colt45 && weapon <= Weapon.Sniper))
        {
            issuer.PlaySound(soundId: 17802);
        }

        if (issuer.Team != player.Team && weapon == Weapon.Sniper && bodyPart == BodyPart.Head)
        {
            PlayerInfo issuerInfo = issuer.GetInfo();
            issuerInfo.AddHeadShots();
            issuerInfo.StatsPerRound.AddCoins(5);
            playerRepository.UpdateHeadShots(issuerInfo);
            player.Health = 0;
            var message = Smart.Format(Messages.HeadshotToPlayer, new
            {
                PlayerName1 = issuer.Name,
                PlayerName2 = player.Name
            });
            worldService.SendClientMessage(Color.Yellow, message);
        }
    }
}
