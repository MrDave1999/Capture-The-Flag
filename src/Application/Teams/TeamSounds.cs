namespace CTF.Application.Teams;

public class TeamSounds
{
    public static readonly TeamSounds None;
    public static readonly TeamSounds Alpha;
    public static readonly TeamSounds Beta;
    static TeamSounds()
    {
        var reader = new EnvReader();
        var defaultValue = string.Empty;
        Alpha = new()
        {
            FlagDropped  = reader.EnvString("RedFlagDroppedUrl",  defaultValue),
            FlagReturned = reader.EnvString("RedFlagReturnedUrl", defaultValue),
            FlagTaken    = reader.EnvString("RedFlagTakenUrl",    defaultValue),
            TeamScores   = reader.EnvString("RedTeamScoresUrl",   defaultValue)
        };

        Beta = new()
        {
            FlagDropped  = reader.EnvString("BlueFlagDroppedUrl",  defaultValue),
            FlagReturned = reader.EnvString("BlueFlagReturnedUrl", defaultValue),
            FlagTaken    = reader.EnvString("BlueFlagTakenUrl",    defaultValue),
            TeamScores   = reader.EnvString("BlueTeamScoresUrl",   defaultValue)
        };

        None = new();
    }

    private TeamSounds() { }
    public string FlagDropped { get; private set; }  = string.Empty;
    public string FlagReturned { get; private set; } = string.Empty;
    public string FlagTaken { get; private set; }    = string.Empty;
    public string TeamScores { get; private set; }   = string.Empty;
}
