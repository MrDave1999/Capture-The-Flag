﻿namespace CaptureTheFlag.PropertiesPlayer;

public class PlayerData
{
    public long AccountNumber { get; set; }
    public int TotalKills { get; set; }
    public int TotalDeaths { get; set; }
    public int KillingSprees { get; set; }
    public int LevelAdmin { get; set; }
    public int LevelVip { get; set; }
    public int LevelGame { get; set; } = 1;
    public int DroppedFlags { get; set; }
    public int Headshots { get; set; }
    public DateTime RegistryDate { get; set; }
    public int SkinId { get; set; } = -1;
}
