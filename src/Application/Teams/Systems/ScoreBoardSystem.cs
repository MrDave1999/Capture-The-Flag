namespace CTF.Application.Teams.Systems;

public class ScoreBoardSystem(IDialogService dialogService) : ISystem
{
    [Event]
    public void OnPlayerKeyStateChange(Player player, Keys newKeys, Keys oldKeys)
    {
        if(KeyUtils.HasPressed(newKeys, oldKeys, Keys.No))
        {
            ShowPlayers(player);
        }
    }

    [PlayerCommand("scoreboard")]
    public void ShowPlayers(Player player)
    {
        Team alphaTeam = Team.Alpha;
        Team betaTeam = Team.Beta;
        var caption = 
            $"{alphaTeam.ColorHex}Alpha Score: {alphaTeam.StatsPerRound.Score} " +
            $"{betaTeam.ColorHex}Beta Score: {betaTeam.StatsPerRound.Score}";
        var columnHeaders = new[]
        {
            "Name",
            "Kills",
            "Deaths"
        };
        var tablistDialog = new TablistDialog(
            caption,
            button1: "Close",
            button2: default,
            columnHeaders);

        var alphaTeamMembers = alphaTeam
            .Members
            .Select(player => player.GetInfo())
            .OrderByDescending(playerInfo => playerInfo.StatsPerRound.Kills);
        foreach (PlayerInfo teamMember in alphaTeamMembers) 
        {
            string[] columns = [
                $"{alphaTeam.ColorHex}{teamMember.Name}",
                $"{alphaTeam.ColorHex}{teamMember.StatsPerRound.Kills}",
                $"{alphaTeam.ColorHex}{teamMember.StatsPerRound.Deaths}"
            ];
            tablistDialog.Add(columns);
        }

        if (alphaTeam.Members.Count > 0)
        {
            tablistDialog.Add(" ", " ", " ");
        }

        var betaTeamMembers = betaTeam
            .Members
            .Select(player => player.GetInfo())
            .OrderByDescending(playerInfo => playerInfo.StatsPerRound.Kills);
        foreach (PlayerInfo teamMember in betaTeamMembers)
        {
            string[] columns = [
                $"{betaTeam.ColorHex}{teamMember.Name}",
                $"{betaTeam.ColorHex}{teamMember.StatsPerRound.Kills}",
                $"{betaTeam.ColorHex}{teamMember.StatsPerRound.Deaths}"
            ];
            tablistDialog.Add(columns);
        }

        dialogService.ShowAsync(player, tablistDialog);
    }
}
