namespace CaptureTheFlag.PropertiesPlayer;

public partial class Player : BasePlayer
{
    public PlayerTextDraw Stats { get; set; }
    public PlayerTextDraw TdRank { get; set; }
    public PlayerTextDraw THealth { get; set; }
    public PlayerTextDraw TArmour { get; set; }

    public void CreateTextDraw()
    {
        THealth = new PlayerTextDraw(this);
        TArmour = new PlayerTextDraw(this);
        Stats = new PlayerTextDraw(this);
        TdRank = new PlayerTextDraw(this);
        TextDrawPlayer.CreateTDHealth(THealth);
        TextDrawPlayer.CreateTDArmour(TArmour);
        TextDrawPlayer.CreateTDStats(Stats);
        TextDrawPlayer.CreateTDRank(TdRank);
    }
}
