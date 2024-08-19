namespace CTF.Application.Players.Weapons;

public class WeaponSystem : ISystem
{
    [Event]
    public void OnPlayerConnect(Player player)
    {
        player.AddComponent<WeaponSelectionComponent>();
    }

    [Event]
    public void OnPlayerSpawn(Player player)
    {
        var weaponSelection = player.GetComponent<WeaponSelectionComponent>();
        WeaponPack selectedWeapons = weaponSelection.SelectedWeapons;
        // Don't user foreach for performance reasons.
        // OnPlayerSpawn is invoked too often.
        for (int i = 0; i < selectedWeapons.Items; i++)
        {
            IWeapon weapon = selectedWeapons[i];
            player.GiveWeapon(weapon.Id, IWeapon.UnlimitedAmmo);
        }
    }

    [PlayerCommand("weapons")]
    public async void ShowWeapons(Player player, IDialogService dialogService)
    {
        var weaponSelection = player.GetComponent<WeaponSelectionComponent>();
        WeaponPack selectedWeapons = weaponSelection.SelectedWeapons;
        var dialog = new ListDialog("Weapons", "Select", "Close");
        var weapons = GtaWeapons.GetAll();
        foreach (IWeapon weapon in weapons)
            dialog.Add(weapon.Name);

        ListDialogResponse response = await dialogService.ShowAsync(player, dialog);
        if (response.Response == DialogResponse.RightButtonOrCancel)
            return;

        IWeapon weaponSelectedFromDialog = GtaWeapons.GetByIndex(response.ItemIndex).Value;
        if (selectedWeapons.Exists(weaponSelectedFromDialog))
        {
            var message = Smart.Format(Messages.WeaponAlreadyExists, weaponSelectedFromDialog);
            player.SendClientMessage(Color.Red, message);
            ShowWeapons(player, dialogService);
            return;
        }

        selectedWeapons.Add(weaponSelectedFromDialog);
        player.GiveWeapon(weaponSelectedFromDialog.Id, IWeapon.UnlimitedAmmo);
        {
            var message = Smart.Format(Messages.WeaponSuccessfullyAdded, weaponSelectedFromDialog);
            player.SendClientMessage(Color.Yellow, message);
        }
        ShowWeapons(player, dialogService);
    }

    [PlayerCommand("pack")]
    public async void ShowWeaponPackage(Player player, IDialogService dialogService)
    {
        var weaponSelection = player.GetComponent<WeaponSelectionComponent>();
        WeaponPack selectedWeapons = weaponSelection.SelectedWeapons;
        if (selectedWeapons.IsEmpty())
        {
            player.SendClientMessage(Color.Red, Messages.EmptyWeaponPackage);
            return;
        }
        var dialog = new ListDialog("Your Weapon Pack", "Remove", "Close");
        foreach (IWeapon weapon in selectedWeapons)
            dialog.Add(weapon.Name);

        ListDialogResponse response = await dialogService.ShowAsync(player, dialog);
        if (response.Response == DialogResponse.RightButtonOrCancel)
            return;

        IWeapon weaponSelectedFromDialog = GtaWeapons.GetByName(response.Item.Text).Value;
        var message = Smart.Format(Messages.WeaponSuccessfullyRemoved, weaponSelectedFromDialog);
        player.SendClientMessage(Color.Red, message);
        selectedWeapons.Remove(weaponSelectedFromDialog);
        player.ResetWeapons();
        foreach (IWeapon weapon in selectedWeapons)
            player.GiveWeapon(weapon.Id, IWeapon.UnlimitedAmmo);
        ShowWeaponPackage(player, dialogService);
    }
}
