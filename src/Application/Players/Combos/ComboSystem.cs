﻿namespace CTF.Application.Players.Combos;

public class ComboSystem : ISystem
{
    private readonly IDialogService _dialogService;
    private readonly TablistDialog _tablistDialog;
    private readonly IWorldService _worldService;
    private readonly PlayerStatsRenderer _playerStatsRenderer;
    private readonly IEnumerable<ICombo> _combos;

    public ComboSystem(
        IDialogService dialogService,
        IWorldService worldService,
        PlayerStatsRenderer playerStatsRenderer,
        IEnumerable<ICombo> combos)
    {
        _dialogService = dialogService;
        _worldService = worldService;
        _playerStatsRenderer = playerStatsRenderer;
        _combos = combos;
        var columnHeaders = new[]
        {
            "Combo",
            "Required Coins"
        };
        _tablistDialog = new TablistDialog(
            caption: "Combos",
            button1: "Select",
            button2: "Close",
            columnHeaders);

        foreach (ICombo combo in combos)
            _tablistDialog.Add(combo.Name, combo.RequiredCoins.ToString());
    }

    [Event]
    public void OnPlayerKeyStateChange(Player player, Keys newKeys, Keys oldKeys)
    {
        if (KeyUtils.HasPressed(newKeys, oldKeys, Keys.AnalogLeft))
        {
            ShowCombos(player);
        }
    }

    [PlayerCommand("combos")]
    public async void ShowCombos(Player player)
    {
        TablistDialogResponse response = await _dialogService.ShowAsync(player, _tablistDialog);
        if (response.IsRightButtonOrDisconnected())
            return;

        string selectedItemName = response.Item.Columns[0];
        ICombo selectedCombo = _combos.First(combo => combo.Name == selectedItemName);
        PlayerStatsPerRound playerStats = player.GetInfo().StatsPerRound;
        if (playerStats.HasInsufficientCoins(selectedCombo.RequiredCoins))
        {
            player.SendClientMessage(Color.Red, Messages.InsufficientCoins);
            ShowCombos(player);
            return;
        }
        GiveComboToPlayer(player, selectedCombo);
    }

    private void GiveComboToPlayer(Player player, ICombo selectedCombo)
    {
        Result result = selectedCombo.Give(player);
        if (result.IsFailed)
        {
            ShowCombos(player);
            return;
        }

        var message = Smart.Format(Messages.RedeemedCoins, new
        {
            PlayerName = player.Name,
            ComboName = selectedCombo.Name
        });
        _worldService.SendClientMessage(Color.Yellow, message);
        _playerStatsRenderer.UpdateTextDraw(player);
    }
}
