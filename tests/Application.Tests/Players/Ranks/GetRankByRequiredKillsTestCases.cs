namespace CTF.Application.Tests.Players.Ranks;

public class GetRankByRequiredKillsTestCases : IEnumerable<(RankId, int)>
{
    public IEnumerator<(RankId, int)> GetEnumerator()
    {
        yield return (RankId.Noob,         0);
        yield return (RankId.Noob,         20);
        yield return (RankId.Noob,         49);
        yield return (RankId.Medium,       50);
        yield return (RankId.Medium,       70);
        yield return (RankId.Medium,       99);
        yield return (RankId.Junior,       100);
        yield return (RankId.Junior,       120);
        yield return (RankId.Junior,       149);
        yield return (RankId.SemiAdvance,  150);
        yield return (RankId.SemiAdvance,  170);
        yield return (RankId.SemiAdvance,  199);
        yield return (RankId.Advanced,     200);
        yield return (RankId.Advanced,     220);
        yield return (RankId.Advanced,     249);
        yield return (RankId.Hitman,       250);
        yield return (RankId.Hitman,       270);
        yield return (RankId.Hitman,       299);
        yield return (RankId.Extreme,      300);
        yield return (RankId.Extreme,      320);
        yield return (RankId.Extreme,      349);
        yield return (RankId.Annihilator,  350);
        yield return (RankId.Annihilator,  370);
        yield return (RankId.Annihilator,  399);
        yield return (RankId.Maniac,       400);
        yield return (RankId.Maniac,       420);
        yield return (RankId.Maniac,       449);
        yield return (RankId.Invincible,   450);
        yield return (RankId.Invincible,   470);
        yield return (RankId.Invincible,   499);
        yield return (RankId.Senior,       500);
        yield return (RankId.Senior,       520);
        yield return (RankId.Senior,       549);
        yield return (RankId.GameMaster,   550);
        yield return (RankId.GameMaster,   570);
        yield return (RankId.GameMaster,   599);
        yield return (RankId.Professional, 600);
        yield return (RankId.Professional, 620);
        yield return (RankId.Professional, 649);
        yield return (RankId.SuperPro,     650);
        yield return (RankId.SuperPro,     670);
        yield return (RankId.SuperPro,     699);
        yield return (RankId.Legendary,    700);
        yield return (RankId.Legendary,    720);
        yield return (RankId.Legendary,    800);
    }

    IEnumerator IEnumerable.GetEnumerator() 
        => this.GetEnumerator();
}
