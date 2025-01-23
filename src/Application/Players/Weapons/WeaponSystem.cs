namespace CTF.Application.Players.Weapons;

public class WeaponSystem : ISystem
{
    private readonly IDialogService _dialogService;
    private readonly ListDialog _weaponsDialog;
    public WeaponSystem(IDialogService dialogService)
    {
        _dialogService = dialogService;
        _weaponsDialog = new ListDialog("Weapons", "Select", "Close");
        var weapons = GtaWeapons.GetAll();
        foreach (IWeapon weapon in weapons)
            _weaponsDialog.Add(weapon.Name);
    }

    [Event]
    public void OnPlayerConnect(Player player)
    {
        player.AddComponent<WeaponSelectionComponent>();
    }

    [Event]
    public void OnPlayerRequestSpawn(Player player) 
    {
        ShowWeapons(player);
        player.SendClientMessage(Color.Orange, Messages.WeaponListUsage);
        player.SendClientMessage(Color.Orange, Messages.WeaponPackUsage);
    }

    [Event]
    public void OnPlayerKeyStateChange(Player player, Keys newKeys, Keys oldKeys)
    {
        if (KeyUtils.HasPressed(newKeys, oldKeys, Keys.Walk | Keys.CtrlBack))
        {
            GiveParachute(player);
        }
        else if (KeyUtils.HasPressed(newKeys, oldKeys, Keys.Yes))
        {
            ShowWeapons(player);
        }
        else if (KeyUtils.HasPressed(newKeys,oldKeys, Keys.CtrlBack))
        {
            ShowWeaponPackage(player);
        }
    }

    [Event]
    public void OnPlayerSpawn(Player player)
    {
        var weaponSelection = player.GetComponent<WeaponSelectionComponent>();
        WeaponPack selectedWeapons = weaponSelection.SelectedWeapons;
        // Don't user foreach for performance reasons.
        // OnPlayerSpawn is invoked too often.
        for (int i = 0; i < selectedWeapons.TotalItems; i++)
        {
            IWeapon weapon = selectedWeapons[i];
            player.GiveWeapon(weapon.Id, IWeapon.UnlimitedAmmo);
        }
    }

    [PlayerCommand("p")]
    public void GiveParachute(Player player)
    {
        player.GiveWeapon(Weapon.Parachute, 1);
    }

    [PlayerCommand("weapons")]
    public async void ShowWeapons(Player player)
    {
        var weaponSelection = player.GetComponent<WeaponSelectionComponent>();
        WeaponPack selectedWeapons = weaponSelection.SelectedWeapons;
        ListDialogResponse response = await _dialogService.ShowAsync(player, _weaponsDialog);
        if (response.IsRightButtonOrDisconnected())
            return;

        IWeapon weaponSelectedFromDialog = GtaWeapons.GetByIndex(response.ItemIndex).Value;
        if (selectedWeapons.Exists(weaponSelectedFromDialog))
        {
            var message = Smart.Format(Messages.WeaponAlreadyExists, weaponSelectedFromDialog);
            player.SendClientMessage(Color.Red, message);
            ShowWeapons(player);
            return;
        }

        selectedWeapons.Add(weaponSelectedFromDialog);
        player.GiveWeapon(weaponSelectedFromDialog.Id, IWeapon.UnlimitedAmmo);
        {
            var message = Smart.Format(Messages.WeaponSuccessfullyAdded, weaponSelectedFromDialog);
            player.SendClientMessage(Color.Yellow, message);
        }
        ShowWeapons(player);
    }

    [PlayerCommand("pack")]
    public async void ShowWeaponPackage(Player player)
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

        ListDialogResponse response = await _dialogService.ShowAsync(player, dialog);
        if (response.IsRightButtonOrDisconnected())
            return;

        IWeapon weaponSelectedFromDialog = GtaWeapons.GetByName(response.Item.Text).Value;
        var message = Smart.Format(Messages.WeaponSuccessfullyRemoved, weaponSelectedFromDialog);
        player.SendClientMessage(Color.Red, message);
        selectedWeapons.Remove(weaponSelectedFromDialog);
        player.ResetWeapons();
        foreach (IWeapon weapon in selectedWeapons)
            player.GiveWeapon(weapon.Id, IWeapon.UnlimitedAmmo);
        ShowWeaponPackage(player);
    }
}
