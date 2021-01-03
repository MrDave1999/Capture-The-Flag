using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Display;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.DataBase
{
    public class Validate
    {
        public static void PasswordRange(Player player, InputDialog dialog, string pass)
        {
            if(pass.Length < 4 || pass.Length > 20)
            {
                dialog.Message = "La contraseña debe estar entre 4 a 20 caracteres.\nIngrese una contraseña:";
                dialog.Show(player);
                throw new Exception();
            }
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
    }
}
