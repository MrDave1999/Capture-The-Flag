namespace CTF.Application.Players.Weapons;

internal class WeaponSystem : ISystem
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
        var selectedWeapons = weaponSelection.SelectedWeapons;
        for (int i = 0; i < selectedWeapons.Count; i++)
        {
            IWeapon weapon = selectedWeapons[i];
            player.GiveWeapon(weapon.Id, IWeapon.UnlimitedAmmo);
        }
    }

    [PlayerCommand("weapons")]
    public async void ShowWeapons(Player player, IDialogService dialogService)
    {
        var weaponSelection = player.GetComponent<WeaponSelectionComponent>();
        var selectedWeapons = weaponSelection.SelectedWeapons;
        var dialog = new ListDialog("Weapons", "Select", "Close");
        var weapons = GtaWeapons.GetAll();
        foreach (IWeapon weapon in weapons)
            dialog.Add(weapon.Name);

        var response = await dialogService.Show(player, dialog);
        if (response.Response == DialogResponse.RightButtonOrCancel)
            return;

        IWeapon weaponSelectedFromDialog = GtaWeapons.GetByIndex(response.ItemIndex).Value;
        bool weaponExists = selectedWeapons.Find(weapon => weapon == weaponSelectedFromDialog) is not null;
        if (weaponExists)
        {
            var message = Smart.Format(Messages.WeaponAlreadyExists, weaponSelectedFromDialog);
            player.SendClientMessage(Color.Red, message);
            ShowWeapons(player, dialogService);
            return;
        }

        int index = selectedWeapons.FindIndex(weapon => weapon.Slot == weaponSelectedFromDialog.Slot);
        bool hasWeaponWithSameCategory = index != -1;
        if (hasWeaponWithSameCategory)
            selectedWeapons[index] = weaponSelectedFromDialog;
        else
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
        var selectedWeapons = weaponSelection.SelectedWeapons;
        if (selectedWeapons.Count == 0)
        {
            player.SendClientMessage(Color.Red, Messages.EmptyWeaponPackage);
            return;
        }
        var dialog = new ListDialog("Your Weapon Package", "Remove", "Close");
        foreach (IWeapon weapon in selectedWeapons)
            dialog.Add(weapon.Name);

        var response = await dialogService.Show(player, dialog);
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
