using CaptureTheFlag.Textdraw;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using System;

namespace CaptureTheFlag.PropertiesPlayer
{
    public partial class Player : BasePlayer
    {
        public override float Health
        {
            get { return base.Health; }
            set
            {
                HealthBar(THealth, value);
                base.Health = value;
            }
        }
        
        public override float Armour
        {
            get { return base.Armour; }
            set
            {
                HealthBar(TArmour, value);
                base.Armour = value;
            }
        }

        public void UpdateBarHealth(DamageEventArgs e)
        {
            if (State == PlayerState.Wasted)
            {
                Armour = 0;
                TArmour.Hide();
                HealthBar(THealth, 0);
            }
            else if (e.Weapon != Weapon.Collision && Armour != 0)
            {
                /* Calculate the player's current armour. */
                float armour = (float)(Armour - Math.Ceiling(e.Amount));
                if (armour > 0)
                    HealthBar(TArmour, armour);
                else
                {
                    TArmour.Hide();
                    HealthBar(THealth, 100.0f - Math.Abs(armour));
                }
            }
            else
            {
                /* Calculate the player's current health. */
                float health = (float)(Health - Math.Ceiling(e.Amount));
                HealthBar(THealth, health >= 0 ? health : 0);
            }
        }

        public void HealthBar(PlayerTextDraw bar, float value)
        {
            bar.Text = $"{value:F0}";
            bar.Show();
        }
    }
}
