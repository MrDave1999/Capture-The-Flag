namespace CTF.Application.Players.Ranks;

public class RankSystem : ISystem
{
    private readonly TablistDialog _tablistDialog;
    public RankSystem()
    {
        var columnHeaders = new[]
        {
            "Rank",
            "Total Required Kills"
        };
        _tablistDialog = new TablistDialog(
            caption: "Ranks",
            button1: "Close",
            button2: null,
            columnHeaders);

        var ranks = RankCollection.GetAll();
        foreach (IRank rank in ranks)
            _tablistDialog.Add(rank.Name, rank.RequiredKills.ToString());
    }

    [PlayerCommand("ranks")]
    public void ShowRanks(Player player, IDialogService dialogService)
    {
        dialogService.ShowAsync(player, _tablistDialog);
    }
}
