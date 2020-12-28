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

        public Gun(Weapon weapon, int slot)
        {
            Weapon = weapon;
            Slot = slot;
        }

        public Gun (Weapon weapon)
        {
            Weapon = weapon;
            Slot = GetWeaponSlot(weapon);
        }

        public static int GetWeaponSlot(Weapon weapon)
        {
            foreach(Gun gun in guns)
                if (gun.Weapon == weapon)
                    return gun.Slot;
            return -1;
        }

        public static Weapon GetWeapon(int index)
        {
            return guns[index].Weapon;
        }

        public static Gun[] GetInstanceArray()
        {
            return guns;
        }
    }
}
