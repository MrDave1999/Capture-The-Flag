namespace CTF.Application.Players.Ranks;

internal class RankSystem : ISystem
{
    [PlayerCommand("ranks")]
    public void ShowRanks(Player player, IDialogService dialogService)
    {
        var columnHeaders = new[] 
        {
            "Rank",
            "Total Required Kills"
        };
        var dialog = new TablistDialog(
            caption: "Ranks", 
            button1: "Close", 
            button2: null,
            columnHeaders);
        var ranks = RankCollection.GetAll();
        foreach (IRank rank in ranks)
            dialog.Add(rank.Name, rank.RequiredKills.ToString());

        dialogService.Show(player, dialog);
    }
}
