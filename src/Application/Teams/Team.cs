﻿namespace CTF.Application.Teams;

public class Team 
{
    public static readonly Team Alpha;
    public static readonly Team Beta;
    public static readonly Team None;
    private Team() { }
    static Team() 
    {
        Alpha = new Team
        {
            Id         = TeamId.Alpha,
            SkinId     = SkinTeamId.Alpha,
            Name       = "Alpha",
            ColorName  = "red",
            GameText   = "~r~",
            ColorHex   = new Color(255, 32, 64, 00),
            Sounds     = TeamSounds.Alpha,
            Flag       = new Flag
            {
                Model  = FlagModel.Red,
                Icon   = FlagIcon.Red,
                Name   = "Red",
                ColorHex = Color.Red
            }
        };

        Beta = new Team
        {
            Id         = TeamId.Beta,
            SkinId     = SkinTeamId.Beta,
            Name       = "Beta",
            ColorName  = "blue",
            GameText   = "~b~",
            ColorHex   = new Color(0, 136, 255, 00),
            Sounds     = TeamSounds.Beta,
            Flag       = new Flag
            {
                Model  = FlagModel.Blue,
                Icon   = FlagIcon.Blue,
                Name   = "Blue",
                ColorHex = Color.Blue
            }
        };

        Alpha.RivalTeam = Beta;
        Beta.RivalTeam  = Alpha;
        None = new NoTeam
        {
            Id         = TeamId.NoTeam,
            SkinId     = SkinTeamId.NoTeam,
            Name       = "NoTeam",
            ColorName  = "white",
            GameText   = "~w~",
            ColorHex   = new Color(255, 255, 255, 00),
            Sounds     = TeamSounds.None,
            Flag       = new Flag
            {
                Model  = FlagModel.None,
                Icon   = FlagIcon.White,
                Name   = "NoTeam",
                ColorHex = Color.White
            },
        };
        None.RivalTeam = None;
    }

    public TeamId Id { get; private set; }
    public SkinTeamId SkinId { get; private set; }
    public string Name { get; private set; }
    public string ColorName { get; private set; }
    public string GameText { get; private set; }
    public Color ColorHex { get; private set; }
    public TeamSounds Sounds { get; private set; }
    public Flag Flag { get; private set; }
    public Team RivalTeam { get; private set; }
    public TeamMembers Members { get; } = [];
    public TeamStatsPerRound StatsPerRound { get; } = new();
    public bool IsFlagAtBasePosition { get; set; } = true;

    public virtual string GetMembersAsText() => $"{Members.Count}";
    public virtual string GetScoreAsText() => $"{Name}: {StatsPerRound.Score}";
    public virtual bool IsFull() => Members.Count > RivalTeam.Members.Count;
    public virtual bool IsWinner() => StatsPerRound.Score > RivalTeam.StatsPerRound.Score;
    public virtual void Reset()
    {
        StatsPerRound.Reset();
        Members.Clear();
        Flag.RemoveCarrier();
        IsFlagAtBasePosition = true;
    }

    public virtual string GetAvailabilityMessage(bool entireMessage = true)
    {
        if (IsFull())
            return entireMessage ? $"~y~{Name}~n~~r~ not available" : "not available";

        return entireMessage ? $"~y~{Name}~n~~r~ available" : "available";
    }

    /// <summary>
    /// Gets the flag status of the current team.
    /// </summary>
    /// <param name="flagPicker">
    /// The player who picks up the flag of the current team.
    /// </param>
    public virtual FlagStatus GetFlagStatus(Player flagPicker)
    {
        ArgumentNullException.ThrowIfNull(flagPicker);
        if (IsFlagAtBasePosition)
        {
            if (flagPicker.Team == (int)RivalTeam.Id)
            {
                IsFlagAtBasePosition = false;
                Flag.SetCarrier(flagPicker);
                return FlagStatus.Captured;
            }

            if (flagPicker == RivalTeam.Flag.Carrier)
            {
                RivalTeam.IsFlagAtBasePosition = true;
                RivalTeam.Flag.RemoveCarrier();
                StatsPerRound.AddScore();
                return FlagStatus.Brought;
            }

            return FlagStatus.InitialPosition;
        }

        if (flagPicker.Team == (int)Id)
        {
            IsFlagAtBasePosition = true;
            return FlagStatus.Returned;
        }

        IsFlagAtBasePosition = false;
        Flag.SetCarrier(flagPicker);
        return FlagStatus.Taken;
    }

    private class NoTeam : Team
    {
        public NoTeam() { }
        public override string GetAvailabilityMessage(bool entireMessage = true) => string.Empty;
        public override FlagStatus GetFlagStatus(Player flagPicker) => FlagStatus.InitialPosition;
        public override string GetMembersAsText() => string.Empty;
        public override string GetScoreAsText() => string.Empty;
        public override bool IsFull() => false;
        public override bool IsWinner() => false;
        public override void Reset()
        {
            StatsPerRound.Reset();
            Members.Clear();
            Flag.RemoveCarrier();
            IsFlagAtBasePosition = true;
        }
    }
}
