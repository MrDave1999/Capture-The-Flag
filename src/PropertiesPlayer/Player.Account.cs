namespace CaptureTheFlag.PropertiesPlayer;

public partial class Player
{
    public void ShowDialogRegister()
    {
        var register = new InputDialog($"{Color.Yellow}Regístrate", $"Esta cuenta no está registrada.\nIngrese una contraseña:", true, "Aceptar", "");
        register.Show(this);
        register.Response += (sender, e) =>
        {
            if (e.DialogButton == DialogButton.Left)
            {
                Validate.IsEmpty(this, register, e.InputText);
                Validate.IsPasswordRange(this, register, e.InputText);
                DataBase.PlayerAccount.Account.Create(this, e.InputText);
                // CmdPublic.Help(this);
                Account = AccountState.None;
                SendClientMessage(Color.Orange, $"[Cuenta]: {Color.Yellow}Te has registrado de forma exitosa. {Color.Orange}Contraseña: {e.InputText}");
            }
            else
                register.Show(this);

        };
    }

    public void ShowDialogLogin(string password)
    {
        var login = new InputDialog($"{Color.Orange}Iniciar Sesión", "Esta cuenta sí está registrada.\nIngrese una contraseña:", true, "Aceptar", "");
        login.Show(this);
        login.Response += (sender, e) =>
        {
            if (e.DialogButton == DialogButton.Left)
            {
                Validate.IsEmpty(this, login, e.InputText);
                Validate.IsPasswordRange(this, login, e.InputText);
                if (password != DataBase.PlayerAccount.Account.Encrypt(e.InputText))
                {
                    login.Message = "La contraseña que ingresaste es incorrecta.\nIngrese una contraseña:";
                    login.Show(this);
                    return;
                }
                if (Data.LevelVip == 3)
                    Adrenaline = 100;
                CmdPublic.StatsPlayer(this);
                Account = AccountState.None;
                SendClientMessage(Color.Orange, $"[Cuenta]: {Color.Yellow}Has iniciado sesión de forma exitosa!");
                AddLevels(this);
            }
            else
                base.Kick();
        };
    }
}
