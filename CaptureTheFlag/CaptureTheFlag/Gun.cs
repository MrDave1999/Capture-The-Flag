using CaptureTheFlag.Constants;
using SampSharp.GameMode.Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    public class Gun
    {
        public Weapon Weapon { get; set; }
        public int Slot { get; set; }

        private static Gun[] guns = new[]
        {
            new Gun(Weapon.Knife,                   1),
            new Gun(Weapon.Silenced,                2),
            new Gun(Weapon.Deagle,                  2),
            new Gun(Weapon.Shotgun,                 3),
            new Gun(Weapon.CombatShotgun,           3),
            new Gun(Weapon.MP5,                     4),
            new Gun(Weapon.AK47,                    5),
            new Gun(Weapon.M4,                      5),
            new Gun(Weapon.Sniper,                  6),
            new Gun(Weapon.Rifle,                   6)
        };

        private Gun(Weapon weapon, int slot)
        {
            Weapon = weapon;
            Slot = slot;
        }

        public static Gun GetWeapon(int index) => guns[index];
        public static Gun GetWeapon(GunID index) => guns[(int)index];
        public static Gun[] GetInstanceArray() => guns;
    }
}
