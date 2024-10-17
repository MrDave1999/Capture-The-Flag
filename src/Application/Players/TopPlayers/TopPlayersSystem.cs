namespace CTF.Application.Players.TopPlayers;

public class TopPlayersSystem(
    IDialogService dialogService,
    ITopPlayersRepository topPlayersRepository) : ISystem
{
    [PlayerCommand("topkills")]
    public void ShowByTotalKills(Player currentPlayer, int maxPlayers = 10)
    {
        Result<MaxTopPlayers> result = MaxTopPlayers.Create(maxPlayers);
        if (result.IsFailed)
        {
            currentPlayer.SendClientMessage(Color.Red, result.Message);
            return;
        }

        var maxTopPlayers = result.Value;
        var columnHeaders = new[]
        {
            "Name",
            "Total Kills",
            "Rank"
        };
        var tablistDialog = new TablistDialog(
            caption: "Top Players By Total Kills",
            button1: "Close",
            button2: null,
            columnHeaders);

        var players = topPlayersRepository.GetByTotalKills(maxTopPlayers);
        foreach (TopPlayersByTotalKills player in players) 
        {
            var columns = new[]
            {
                player.PlayerName, 
                player.TotalKills.ToString(), 
                player.Rank.ToString()
            };
            tablistDialog.Add(columns);
        }
        dialogService.ShowAsync(currentPlayer, tablistDialog);
    }

    [PlayerCommand("topspree")]
    public void ShowByMaxKillingSpree(Player currentPlayer, int maxPlayers = 10)
    {
        Result<MaxTopPlayers> result = MaxTopPlayers.Create(maxPlayers);
        if (result.IsFailed)
        {
            currentPlayer.SendClientMessage(Color.Red, result.Message);
            return;
        }

        var maxTopPlayers = result.Value;
        var columnHeaders = new[]
        {
            "Name",
            "Killing Spree"
        };
        var tablistDialog = new TablistDialog(
            caption: "Top Players By Maximum Killing Spree",
            button1: "Close",
            button2: null,
            columnHeaders);

        var players = topPlayersRepository.GetByMaxKillingSpree(maxTopPlayers);
        foreach (TopPlayersByMaxKillingSpree player in players)
        {
            var columns = new[]
            {
                player.PlayerName,
                player.MaxKillingSpree.ToString()
            };
            tablistDialog.Add(columns);
        }
        dialogService.ShowAsync(currentPlayer, tablistDialog);
    }
}
