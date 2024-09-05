namespace CTF.Application.Players.Combos;

public class ComboSystem : ISystem
{
    private readonly IDialogService _dialogService;
    private readonly TablistDialog _tablistDialog;
    private readonly IWorldService _worldService;
    private readonly IEnumerable<IBenefit> _benefits;

    public ComboSystem(
        IDialogService dialogService,
        IWorldService worldService,
        IEnumerable<IBenefit> benefits)
    {
        _dialogService = dialogService;
        _worldService = worldService;
        _benefits = benefits;
        var columnHeaders = new[]
        {
            "Combo",
            "Required Points"
        };
        _tablistDialog = new TablistDialog(
            caption: "Combos",
            button1: "Select",
            button2: "Close",
            columnHeaders);

        foreach (IBenefit benefit in benefits)
            _tablistDialog.Add(benefit.Name, benefit.RequiredPoints.ToString());
    }

    [PlayerCommand("combos")]
    public async void ShowCombos(Player player)
    {
        TablistDialogResponse response = await _dialogService.ShowAsync(player, _tablistDialog);
        if (response.Response == DialogResponse.RightButtonOrCancel)
            return;

        string selectedItemName = response.Item.Columns[0];
        IBenefit selectedBenefit = _benefits.First(benefit => benefit.Name == selectedItemName);
        PlayerStatsPerRound playerStats = player.GetInfo().StatsPerRound;
        if(playerStats.HasInsufficientPoints(selectedBenefit.RequiredPoints))
        {
            player.SendClientMessage(Color.Red, Messages.InsufficientPoints);
            ShowCombos(player);
            return;
        }

        var message = Smart.Format(Messages.RedeemedPoints, new 
        { 
            PlayerName  = player.Name,
            BenefitName = selectedBenefit.Name
        });
        _worldService.SendClientMessage(Color.Yellow, message);
        selectedBenefit.Give(player);
        ShowCombos(player);
    }
}
