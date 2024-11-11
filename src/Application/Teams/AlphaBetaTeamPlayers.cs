namespace CTF.Application.Teams;

public class AlphaBetaTeamPlayers
{
    private AlphaBetaTeamPlayers() { }

    /// <summary>
    /// Gets all players from the Alpha and Beta teams.
    /// </summary>
    public static IEnumerable<Player> GetAll()
    {
        TeamMembers alphaTeamMembers = Team.Alpha.Members;
        foreach (Player player in alphaTeamMembers) 
        { 
            yield return player;
        }

        TeamMembers betaTeamMembers = Team.Beta.Members;
        foreach (Player player in betaTeamMembers)
        {
            yield return player;
        }
    }
}
