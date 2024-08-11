namespace CTF.Application.Players.Accounts;

public class PlayerStatsPerRound
{
    public int Kills { get; private set; }
    public int Deaths { get; private set; }
    public int KillingSpree { get; private set; }
    public int Points { get; private set; }

    public void AddKills() => Kills++;
    public void AddDeaths() => Deaths++;
    public void AddKillingSpree() => KillingSpree++;
    public bool HasSufficientPoints(int amount) => Points >= amount;
    public bool HasInsufficientPoints(int amount) => !HasSufficientPoints(amount);

    public Result AddPoints(int value)
    {
        if (value < 1 || value > 100)
            return Result.Failure(Messages.AddPoints);

        Points += value;
        if(Points > 100) 
            Points = 100;

        return Result.Success();
    }

    public Result SubtractPoints(int value)
    {
        if (value < -100 || value > -1)
            return Result.Failure(Messages.SubtractPoints);

        Points -= -value;
        if(Points < 0) 
            Points = 0;

        return Result.Success();
    }

    public void ResetPoints() => Points = 0;
    public void ResetKills()  => Kills = 0;
    public void ResetDeaths() => Deaths = 0;
    public void ResetKillingSpree() => KillingSpree = 0;
    public void ResetStats()
    {
        Kills = 0;
        Deaths = 0;
        KillingSpree = 0;
        Points = 0;
    }
}
