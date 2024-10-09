namespace CTF.Application.Players.GeneralCommands;

public class VipCommands : ISystem
{
    [PlayerCommand("cmdsvip")]
    public void ShowVipCommands(Player player, IDialogService dialogService)
    {
        if (player.HasLowerRoleThan(RoleId.VIP))
            return;

        var commands =
        """
        {Color1}/armour: {Color2}Grants you temporary armour, reducing damage taken from attacks.
        {Color1}/health: {Color2}Restores a portion of your health instantly.
        {Color1}/saw: {Color2}Deploys a powerful saw to cut through obstacles or defeat enemies.
        {Color1}/spray: {Color2}Releases a spray that can confuse and distract opponents.
        {Color1}/teargas: {Color2}Deploys tear gas, impairing visibility and causing disorientation to nearby enemies.
        {Color1}/givemecoins: {Color2}Awards you with in-game coins, enhancing your resources.

        {Color1}Use the '$' symbol at the start of your message to access the private VIP chat.
        """;
        var content = Smart.Format(commands, new 
        { 
            Color1 = Color.Yellow,
            Color2 = Color.White
        });
        var dialog = new MessageDialog(caption: "VIP Commands", content, "Close");
        dialogService.ShowAsync(player, dialog);
    }

    [PlayerCommand("saw")]
    public void Saw(Player player)
    {
        if (player.HasLowerRoleThan(RoleId.VIP))
            return;

        player.GiveWeapon(Weapon.Chainsaw, 1);
    }

    [PlayerCommand("spray")]
    public void Spray(Player player) 
    {
        if (player.HasLowerRoleThan(RoleId.VIP))
            return;

        player.GiveWeapon(Weapon.Spraycan, IWeapon.UnlimitedAmmo);
    }

    [PlayerCommand("teargas")]
    public void Teargas(Player player)
    {
        if (player.HasLowerRoleThan(RoleId.VIP))
            return;

        player.GiveWeapon(Weapon.Teargas, IWeapon.UnlimitedAmmo);
    }
}
