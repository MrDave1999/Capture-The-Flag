using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.YSF;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag
{
    public class Validate
    {
        public static void IsPasswordRange(Player player, InputDialog dialog, string pass)
        {
            if(pass.Length < 4 || pass.Length > 20)
            {
                dialog.Message = "La contraseña debe tener entre 4 y 20 caracteres.\nIngrese una contraseña:";
                dialog.Show(player);
                throw new Exception();
            }
        }

        public static bool IsNameRange(Player player, string name)
        {
            if(name.Length < 3 || name.Length > 20)
            {
                player.SendClientMessage(Color.Red, "Error: La longitud del nombre debe tener entre 3 y 20 caracteres.");
                return false;
            }
            return true;
        }

        public static void IsEmpty(Player player, InputDialog dialog, string text)
        {
            if(text.Trim().Length == 0)
            {
                dialog.Message = "No puedes dejar el campo vacío.\nIngrese una contraseña:";
                dialog.Show(player);
                throw new Exception();
            }
        }

        public static bool IsValidName(Player player, string name)
        {
            if (!YSF.IsValidNickName(name))
            {
                player.SendClientMessage(Color.Red, "Error: El nombre que ingresaste no es válido.");
                player.SendClientMessage(Color.Red, "* Caracteres válidos: 0-9, a-z, A-Z, [], (), $ @ . _");
                return false;
            }
            return true;
        }
    }
}
