namespace CTF.Application.Players.Combos.Benefits;

public class HealthArmour : IBenefit
{
    public string Name => "150 Health and 100 Armour";
    public int RequiredPoints => 100;

    public void Give(Player player)
    {
        PlayerInfo playerInfo = player.GetInfo();
        player.Health = 150;
        player.Armour = 100;
        playerInfo.StatsPerRound.ResetPoints();
    }
}
