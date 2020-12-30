using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.Tools;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
	public partial class Player
    {
		public int PtsLastFiredWeapon { get; set; }
		public int WarningsCBug { get; set; }
	}

    public class AntiCBug
    {
		static AntiCBug()
        {
            BaseMode.Instance.PlayerKeyStateChanged += OnPlayerKeyStateChanged;
        }

        public static void OnPlayerKeyStateChanged(object sender, KeyStateChangedEventArgs e)
        {
			var player = sender as Player;
			if (KeyUtils.HasPressed(e, Keys.Fire))
			{
				switch (player.Weapon)
                {
					case Weapon.Deagle:
					case Weapon.Shotgun:
					case Weapon.Sniper:
					case Weapon.Rifle:
					case Weapon.CombatShotgun:
					case Weapon.Silenced:
					case Weapon.M4:
					case Weapon.AK47:
					case Weapon.MP5:
						player.PtsLastFiredWeapon = Time.GetTime();
						break;
                }
			}
			else if (KeyUtils.HasPressed(e, Keys.Crouch))
			{
				if ((Time.GetTime() - player.PtsLastFiredWeapon) < 1)
				{
					++player.WarningsCBug;
					new MessageDialog($"{Color.Red}Anti C-Bug", $"{Color.Yellow}En este servidor está prohibido el C-Bug, no seas noob!\nAdvertencia: {player.WarningsCBug}/3", "Cerrar", "").Show(player);
					if(player.WarningsCBug == 3)
						player.Kick();
				}
			}
		}
    }
}
