namespace CTF.Application.Players.Ranks;

internal class RankCollection
{
    private static readonly Rank[] s_ranks = 
    [
        new(RankId.Noob,         0),
        new(RankId.Medium,       50),
        new(RankId.Junior,       100),
        new(RankId.SemiAdvance,  150),
        new(RankId.Advanced,     200),
        new(RankId.Hitman,       250),
        new(RankId.Extreme,      300),
        new(RankId.Annihilator,  350),
        new(RankId.Maniac,       400),
        new(RankId.Invincible,   450),
        new(RankId.Senior,       500),
        new(RankId.GameMaster,   550),
        new(RankId.Professional, 600),
        new(RankId.SuperPro,     650),
        new(RankId.Legendary,    700)
    ];

    private RankCollection() { }
    public static int Max => s_ranks.Length;
    public static IReadOnlyList<IRank> GetAll() => s_ranks;
    public static Result<IRank> GetById(RankId id)
    {
        if ((int)id < 0 || (int)id >= Max)
            return Result<IRank>.Failure(Messages.InvalidRank);

        Rank rank = s_ranks[(int)id];
        return Result<IRank>.Success(rank);
    }
    public static Result<IRank> GetByRequiredKills(int value)
    {
        if (value < 0)
            return Result<IRank>.Failure(Messages.ValueCannotBeNegative);

        foreach (IRank rank in s_ranks)
        {
            if (rank.IsMax())
                break;

            IRank nextRank = GetNextRank(rank.Id).Value;
            if (value >= rank.RequiredKills && value < nextRank.RequiredKills)
                return Result<IRank>.Success(rank);
        }

        IRank maxRank = s_ranks[Max - 1];
        return Result<IRank>.Success(maxRank);
    }
    public static Result<IRank> GetNextRank(RankId previous)
    {
        if ((int)previous < 0 || (int)previous >= Max)
            return Result<IRank>.Failure(Messages.InvalidRank);

        Rank rank = ((int)previous + 1 == Max) ? 
            Rank.None :
            s_ranks[(int)previous + 1];

        return Result<IRank>.Success(rank);
    }

    private class Rank : IRank
    {
        public static readonly Rank None = new();
        public RankId Id { get; } = (RankId)(-1);
        public string Name { get; } = "None";
        public int RequiredKills { get; }

        public Rank() { }
        public Rank(RankId id, int requiredKills)
        {
            Id = id;
            Name = id.ToString();
            RequiredKills = requiredKills;
        }
        public bool IsMax() => Max == (int)Id + 1;
        public bool IsNotMax() => !IsMax();
    }
}
