using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptureTheFlag.Command.Public
{
    public class CategoryCommand
    {
        /* To have the reference of the main menu. */
        public ListDialog DialogMain { get; set; }
        /* The instance of the dialog representing the category is saved. */
        public MessageDialog DialogCategory { get; set; }

        public CategoryCommand()
        {
            DialogCategory = new MessageDialog(" ", "", "Atrás", "Cerrar");
            DialogCategory.Response += (sender, e) =>
            {
                if (e.DialogButton == DialogButton.Left)
                    DialogMain.Show(e.Player);
            };
        }

        public void ShowGeneral()
        {
            DialogCategory.Message = 
                $"{Color.Yellow}/help{Color.White} - Muestra información sobre como se debe jugar." +
                $"\n{Color.Yellow}/credits{Color.White} - Muestra las personas que han participado en la creación de la GM." +
                $"\n{Color.Yellow}/ranks{Color.White} - Muestra la lista de rangos disponibles." +
                $"\n{Color.Yellow}/rules{Color.White} - Muestra las reglas que se deben cumplir en el servidor." +
                $"\n{Color.Yellow}/infoadmin{Color.White} - Muestra información sobre como ser admin en el servidor." +
                $"\n{Color.Yellow}/top{Color.White} - Muestra un menú de Tops como por ejemplo: TopKills, TopDeaths, etc." +
                $"\n{Color.Yellow}/users{Color.White} - Muestra una tabla de posiciones separados por equipos."
            ;
        }

        public void ShowWeapons()
        {
            DialogCategory.Message =
                $"{Color.Yellow}/weapons{Color.White} - Muestra la lista de armas a elegir." +
                $"\n{Color.Yellow}/packet{Color.White} - Muestra el paquete actual de armas del jugador." +
                $"\n{Color.Yellow}/combos{Color.White} - Muestra los combos que podrás canjear por adrenalina." 
           ;
        }

        public void ShowPM()
        {
            DialogCategory.Message =
                $"{Color.Yellow}/pm{Color.White} - Envía un mensaje privado a un jugador en especifico." +
                $"\n{Color.Yellow}/ypm{Color.White} - Habilita los mensajes privados." +
                $"\n{Color.Yellow}/npm{Color.White} - Inhabilita los mensajes privados." +
                $"\n{Color.Yellow}/r{Color.White} - Envía un mensaje privado al último jugador que te envió un mensaje."
            ;
        }

        public void ShowAFK()
        {
            DialogCategory.Message =
                 $"{Color.Yellow}/afk{Color.White} - Permite que el jugador pueda alejarse del teclado por tiempo indeterminado." +
                $"\n{Color.Yellow}/outafk{Color.White} - Permite al jugador salirse del modo AFK." +
                $"\n{Color.Yellow}/afks{Color.White} - Muestra un listado de los jugadores que están en AFK."
            ;
        }

        public void ShowStats()
        {
            DialogCategory.Message =
                $"{Color.Yellow}/tstats{Color.White} - Muestra las estadísticas de ambos equipos (Alpha y Beta)." +
                $"\n{Color.Yellow}/stats{Color.White} - Muestra las estadísticas de un jugador conectado." +
                $"\n{Color.Yellow}/statsdb{Color.White} - Muestra las estadísticas de un jugador desconectado." +
                $"\n{Color.Yellow}/changepass{Color.White} - Cambia la contraseña de la cuenta del jugador." +
                $"\n{Color.Yellow}/changename{Color.White} - Cambia el nombre de la cuenta del jugador."
            ;
        }

        public void ShowShortcurts()
        {
            DialogCategory.Message =
                $"{Color.Yellow}Tecla H:{Color.White} Invoca al comando /combos." +
                $"\n{Color.Yellow}Tecla Y:{Color.White} Invoca al comando /weapons." +
                $"\n{Color.Yellow}Tecla N:{Color.White} Muestra la lista de usuarios conectados (por equipo)." +
                $"\n{Color.Yellow}ALT + C:{Color.White} Invoca al comando /packet." +
                $"\n{Color.Yellow}ALT + H:{Color.White} Invoca al comando /cmds." +
                $"\n{Color.Yellow}NUM 4:{Color.White} Invoca al comando /top." +
                $"\n{Color.Yellow}NUM 6:{Color.White} Invoca al comando /help." 
            ;
        }

        public void ShowSigns()
        {
            DialogCategory.Message =
                $"{Color.Yellow}Signo (!):{Color.White} Permite hablar en el TeamChat (ejemplo: {Color.Pink}!texto{Color.White})." +
                $"\n{Color.Yellow}Signo (#):{Color.White} Permite hablar en el AdminChat (ejemplo: {Color.Pink}#texto{Color.White})." +
                $"\n{Color.Yellow}Signo ($):{Color.White} Permite hablar en el VipChat (ejemplo: {Color.Pink}$texto{Color.White})." +
                $"\n{Color.Yellow}Signo (&):{Color.White} Permite hablar como Administrador (ejemplo: {Color.Pink}&texto{Color.White})." +
                $"\n{Color.Yellow}Signo (@):{Color.White} Permite hablar como usuario VIP (ejemplo: {Color.Pink}@texto{Color.White})." +
                $"\n{Color.Yellow}Signo (~):{Color.White} Permite hablar como usuario anónimo (ejemplo: {Color.Pink}~texto{Color.White})."
            ;
        }

        public void ShowOthers()
        {
            DialogCategory.Message =
                $"{Color.Yellow}/kill{Color.White} - Asesina al jugador (su vida queda en 0.0)." +
                $"\n{Color.Yellow}/datetime{Color.White} - Obtiene la fecha y hora local del servidor." +
                $"\n{Color.Yellow}/switch{Color.White} - Permite al jugador cambiarse de equipo." +
                $"\n{Color.Yellow}/tc{Color.White} - Permite hablar en el Team Chat." +
                $"\n{Color.Yellow}/re{Color.White} - Reinicia a 0 los asesinatos y muertes por ronda." +
                $"\n{Color.Yellow}/admins{Color.White} - Muestra la lista de administradores que están conectados." +
                $"\n{Color.Yellow}/admin{Color.White} - Muestra los niveles administrativos." +
                $"\n{Color.Yellow}/vips{Color.White} - Muestra los usuarios VIP que están conectados." +
                $"\n{Color.Yellow}/vip{Color.White} - Muestra los niveles VIP." +
                $"\n{Color.Yellow}/report{Color.White} - Sirve para reportar a un jugador." +
                $"\n{Color.Yellow}/music{Color.White} - Permite escuchar música por medio de una URL." +
                $"\n{Color.Yellow}/stop{Color.White} - Detiene la música." +
                $"\n{Color.Yellow}/map{Color.White} - Muestra el mapa actual del servidor."
            ;
        }

    }

    public partial class CmdPublic
    {

    }
}
