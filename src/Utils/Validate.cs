namespace CaptureTheFlag.Utils;
public class Validate
{
    public static void IsPasswordRange(Player player, InputDialog dialog, string pass)
    {
        if (pass.Length < 4 || pass.Length > 20)
        {
            dialog.Message = "La contraseña debe tener entre 4 y 20 caracteres.\nIngrese una contraseña:";
            dialog.Show(player);
            throw new Exception();
        }
    }

    public static bool IsNameRange(Player player, string name)
    {
        if (name.Length < 3 || name.Length > 20)
        {
            player.SendClientMessage(Color.Red, "Error: La longitud del nombre debe tener entre 3 y 20 caracteres.");
            return false;
        }
        return true;
    }

    public static void IsEmpty(Player player, InputDialog dialog, string text)
    {
        if (text.Trim().Length == 0)
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

    public static void IsTotalDaysRange(Player player, int days)
    {
        if (days < 1 || days > 365)
        {
            player.SendClientMessage(Color.Red, "Error: Los días deben estar entre 1 a 365 días.");
            throw new Exception();
        }
    }

    public static void IsHoursRange(Player player, int hours)
    {
        if (hours < 0 || hours > 23)
        {
            player.SendClientMessage(Color.Red, "Error: Las horas deben estar entre 0 a 23 horas.");
            throw new Exception();
        }
    }

    public static void IsMinutesRange(Player player, int minutes)
    {
        if (minutes < 0 || minutes > 59)
        {
            player.SendClientMessage(Color.Red, "Error: Los minutos deben estar entre 0 a 59 minutos.");
            throw new Exception();
        }
    }

    public static void IsSecondsRange(Player player, int seconds)
    {
        if (seconds < 0 || seconds > 59)
        {
            player.SendClientMessage(Color.Red, "Error: Los segundos deben estar entre 0 a 59 segundos.");
            throw new Exception();
        }
    }
}