namespace CTF.Application.Teams;

public class TeamSounds
{
    public static readonly TeamSounds None = new();
    public static readonly TeamSounds Alpha = new()
    {
        FlagDropped  = "https://od.lk/s/Nl8yMDg4MTc0MzNf/red_flag_dropped.mp3",
        FlagReturned = "https://od.lk/s/Nl8yMDg4MTc0MzRf/red_flag_returned.mp3",
        FlagTaken    = "https://od.lk/s/Nl8yMDg4MTc0MzVf/red_flag_taken.mp3",
        TeamScores   = "https://od.lk/s/Nl8yMDg4MTc0MzZf/red_team_scores.mp3"
    };

    public static readonly TeamSounds Beta = new()
    {
        FlagDropped  = "https://od.lk/s/Nl8yMDg4MTc0Mjlf/blue_flag_dropped.mp3",
        FlagReturned = "https://od.lk/s/Nl8yMDg4MTc0MzBf/blue_flag_returned.mp3",
        FlagTaken    = "https://od.lk/s/Nl8yMDg4MTc0MzFf/blue_flag_taken.mp3",
        TeamScores   = "https://od.lk/s/Nl8yMDg4MTc0MzJf/blue_team_scores.mp3"
    };

    private TeamSounds() { }
    public string FlagDropped { get; private set; }  = string.Empty;
    public string FlagReturned { get; private set; } = string.Empty;
    public string FlagTaken { get; private set; }    = string.Empty;
    public string TeamScores { get; private set; }   = string.Empty;
}
