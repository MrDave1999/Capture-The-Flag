using CaptureTheFlag.PropertiesPlayer;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.SAMP.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using static CaptureTheFlag.Events.GameMode;

namespace CaptureTheFlag.Command.Public
{
    public partial class CmdPublic
    {
        [Command("cmds", Shortcut = "cmds")]
        private static void ListCommands(Player player)
        {
            new MessageDialog(" ",
                $"{Color.Orange}Comandos:" +
                $"\n{Color.Yellow}/kill - {Color.White} Asesina al jugador (su vida queda en 0.0)." +
                $"\n{Color.Yellow}/tstats - {Color.White} Muestra las estadísticas de ambos equipos (Alpha y Beta)." +
                $"\n{Color.Yellow}/switch - {Color.White} Permite al jugador cambiarse de equipo." +
                $"\n{Color.Yellow}/tc - {Color.White} Permite hablar en el Team Chat." +
                $"\n{Color.Yellow}/re{Color.White} Reinicia a 0 los asesinatos y muertes por ronda." +
                $"\n{Color.Yellow}/help - {Color.White} Muestra información sobre como se debe jugar." +
                $"\n{Color.Yellow}/credits - {Color.White} Muestra las personas que han participado en la creación de la GM." +
                $"\n{Color.Yellow}/admins{Color.White} - Muestra la lista de administradores que están conectados." +
                $"\n{Color.Yellow}/vips{Color.White} - Muestra los usuarios VIP que están conectados." +
                $"\n{Color.Yellow}/stats{Color.White} - Muestra las estadísticas de un jugador conectado." +
                $"\n{Color.Yellow}/statsdb{Color.White} - Muestra las estadísticas de un jugador desconectado." +
                $"\n{Color.Yellow}/changepass{Color.White} - Cambia la contraseña de la cuenta del jugador." +
                $"\n{Color.Yellow}/changename{Color.White} - Cambia el nombre de la cuenta del jugador." +
                $"\n{Color.Yellow}/pm{Color.White} - Envía un mensaje privado a un jugador en especifico." +
                $"\n{Color.Yellow}/ypm{Color.White} - Habilita los mensajes privados." +
                $"\n{Color.Yellow}/npm{Color.White} - Inhabilita los mensajes privados." +
                $"\n{Color.Yellow}/r{Color.White} - Envía un mensaje privado al último jugador que te envió un mensaje." +
                $"\n{Color.Yellow}/report{Color.White} - Sirve para reportar a un jugador." +
                $"\n{Color.Yellow}/combos{Color.White} - Muestra los combos que podrás canjear por adrenalina." +
                $"\n{Color.Yellow}/ranks{Color.White} - Muestra la lista de rangos disponibles." +
                $"\n{Color.Yellow}/weapons{Color.White} - Muestra la lista de armas a elegir." +
                $"\n{Color.Yellow}/packet{Color.White} - Muestra el paquete actual de armas del jugador." +
                $"\n{Color.Yellow}/music{Color.White} - Permite escuchar música por medio de una URL." +
                $"\n{Color.Yellow}/stop{Color.White} - Detiene la música." +
                $"\n\n{Color.Orange}Teclas:" +
                $"\n{Color.Yellow}Tecla H:{Color.White} Muestra el listado de combos a canjear (por adrenalina)." +
                $"\n{Color.Yellow}Tecla Y:{Color.White} Muestra un menú de armas." +
                $"\n{Color.Yellow}Tecla N:{Color.White} Muestra la lista de usuarios conectados (por equipo)." +
                $"\n\n{Color.Orange}Signos:" +
                $"\n{Color.Yellow}Signo (!):{Color.White} Permite hablar en el TeamChat (ejemplo: {Color.Pink}!texto{Color.White})." +
                $"\n{Color.Yellow}Signo (#):{Color.White} Permite hablar en el AdminChat (ejemplo: {Color.Pink}#texto{Color.White})." +
                $"\n{Color.Yellow}Signo ($):{Color.White} Permite hablar en el VipChat (ejemplo: {Color.Pink}$texto{Color.White}).", "Aceptar").Show(player);
        }

        [Command("help", Shortcut = "help")]
        public static void Help(Player player)
        {
            new MessageDialog("Ayuda",
                $"{Color.Yellow}¿Qué es Capture The Flag?" +
                $"\n{Color.White}Capture The Flag es un estilo de juego en el que dos equipos intentan atrapar una bandera." +
                $"\n{Color.White}Si el jugador captura la bandera, debe llevarla a un sitio determinado para que su equipo gane puntos." +
                $"\n{Color.White}Para jugar, los jugadores se dividen en dos equipos, con cada uno en un campo." +
                $"\n{Color.White}Para poder ganar, hay que coger una bandera y llevarla a un determinado sitio." +
                $"\n\n{Color.Yellow}¿A dónde llevo la bandera?" +
                $"\n{Color.White}Si capturaste la bandera, la debes llevar a la posición base donde se encuentre la bandera de tu equipo. " +
                $"\n{Color.White}Esa “posición base” es identificada por un ícono que aparecerá en el mapa radar." +
                $"\n{Color.White}Si eres del equipo {TeamAlpha.OtherColor}Alpha{Color.White}, el ícono será de color {TeamAlpha.OtherColor}Rojo {Color.White}y si eres del equipo {TeamBeta.OtherColor}Beta{Color.White}, el ícono será de color {TeamBeta.OtherColor}Azul." +
                $"\n\n{Color.Yellow}¿Qué pasa si no encuentro la bandera de mi equipo en la posición base?" +
                $"\n{Color.White}Pues tu equipo no ganará puntos. En ese caso, debes recuperar la bandera de tu equipo." +
                $"\n\n{Color.Yellow}¿Cómo recupero la bandera de mi equipo?" +
                $"\n{Color.White}Simple, debes matar al jugador que robó la bandera." +
                $"\n{Color.White}Aunque puede que la bandera quede en algún sitio que no sea la posición base y te toque buscarla." +
                $"\n\n{Color.Yellow}¿Cómo sé quien se robó la bandera de mi equipo?" +
                $"\n{Color.White}Con el comando {Color.Pink}/tstats.", "Aceptar").Show(player);
        }

        [Command("credits", Shortcut = "credits")]
        private static void Credits(Player player)
        {
            new MessageDialog("Créditos",
                $"{Color.Yellow}Capture The Flag es un proyecto Open Source." +
                $"\n{Color.Orange}Repositorio: {Color.White}https://github.com/MrDave1999/Capture-The-Flag" +
                $"\n{Color.Orange}Creador/Fundador: {Color.White}MrDave1999." +
                $"\n{Color.Orange}Programador: {Color.White}MrDave1999." +
                $"\n{Color.Orange}Mapeadores: {Color.White}DragonZafiro, Elorreli, amirab, JamesT85," +
                $"\nTheYoungCapone, B4MB1[MC], Sleyer, mihaibr, UnuAlex," +
                 $"\nSpikY_, Niktia_Ruchkov, Amads, Samarchai, haubitze." +
                $"\n{Color.Yellow}Agradecimientos a:" +
                $"\n{Color.Orange}ikkentim {Color.White}por crear SampSharp." +
                $"\n{Color.Orange}rickyah {Color.White}por crear ini-parser." +
                $"\n{Color.Orange}Nickk888SAMP {Color.White}por crear NTD (TextDraw Editor)." +
                $"\n{Color.Orange}samp-incognito {Color.White}por crear streamer-plugin." +
                $"\n{Color.Orange}Ts-Pytham {Color.White}por colaborar con el sistema de administración." +
                $"\n{Color.Orange}critical99 {Color.White}por hacer la versión YSF Lite." +
                $"\n{Color.Orange}BlasterDv {Color.White}por crear el Wrapper SampSharp.YSF." +
                $"\n\n{Color.Yellow}¡Eres libre de contribuir en el proyecto!", "Aceptar").Show(player);
        }
    }
}
