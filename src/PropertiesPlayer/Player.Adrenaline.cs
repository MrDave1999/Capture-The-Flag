namespace CaptureTheFlag.PropertiesPlayer;

public partial class Player : BasePlayer
{
    private int adrenaline;

    public int Adrenaline
    {
        get { return adrenaline; }
        set
        {
            /* This is used when adrenaline resets to zero. */
            if (value == 0)
            {
                adrenaline = 0;
                TextDrawPlayer.UpdateTdStats(this);
            }
            else if (value < 0)
            {
                adrenaline -= -value;
                TextDrawPlayer.UpdateTdStats(this);
            }
            else if (adrenaline < 100)
            {
                /* The percentage of adrenaline that the player won. */
                int won_adrenaline = value - adrenaline;
                /* The percentage of adrenaline the player lacks to complete 100 percent. */
                int missing_adrenaline = 100 - adrenaline;
                adrenaline = (won_adrenaline <= missing_adrenaline) ? (value) : (adrenaline + missing_adrenaline);
                if (adrenaline == 100)
                    SendClientMessage(Color.Yellow, message: $"* Tu adrenalina está al 100 %% ({Color.Red}usa /combos {Color.Yellow}para poder canjear la adrenalina por algún {Color.Red}beneficio{Color.Yellow}).");
            }
        }
    }

    public void UpdateAdrenaline(int won_adrenaline, string reason)
    {
        if (adrenaline < 100)
        {
            Adrenaline += won_adrenaline;
            SendClientMessage(Color.Pink, $"[!]{Color.White} Obtuviste +{won_adrenaline} de {Color.Pink}Adrenalina {Color.White}por {reason}.");
            TextDrawPlayer.UpdateTdStats(this);
        }
    }

    public void HasAdrenaline(int amount)
    {
        if (Adrenaline < amount)
        {
            SendClientMessage(Color.Red, "Error: No tienes suficiente adrenalina.");
            throw new Exception();
        }
    }
}
