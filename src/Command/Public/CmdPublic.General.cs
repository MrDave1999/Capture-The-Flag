namespace CaptureTheFlag.Command.Public;

public partial class CmdPublic
{
    [Command("cmds", Shortcut = "cmds")]
    public static void ListCommands(Player player)
    {
        var dialog = new ListDialog("Menu", "Seleccionar", "Cerrar");
        dialog.AddItems(new[]
        {
            "General",
            "Armas",
            "Mensajes Privados",
            "AFK",
            "Estadísticas",
            "Atajos",
            "Signos",
            "Otros comandos"
        });
        var category = new CategoryCommand() { DialogMain = dialog };
        dialog.Response += (sender, e) =>
        {
            if(e.DialogButton == DialogButton.Left)
            {
                category.DialogCategory.Message = "";
                category.DialogCategory.Caption = dialog.Items[e.ListItem];
                switch (e.ListItem)
                {
                    case 0:
                        category.ShowGeneral();
                        break;
                    case 1:
                        category.ShowWeapons();
                        break;
                    case 2:
                        category.ShowPM();
                        break;
                    case 3:
                        category.ShowAFK();
                        break;
                    case 4:
                        category.ShowStats();
                        break;
                    case 5:
                        category.ShowShortcurts();
                        break;
                    case 6:
                        category.ShowSigns();
                        break;
                    case 7:
                        category.ShowOthers();
                        break;
                }
                category.DialogCategory.Show(player);
            }
        };
        dialog.Show(player);
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
            $"\n{Color.Orange}Repositorio Oficial: {Color.White}https://github.com/ctf-samp/Capture-The-Flag" +
            $"\n{Color.Orange}Creador/Fundador: {Color.White}MrDave1999." +
            $"\n{Color.Orange}Programador: {Color.White}MrDave1999." +
            $"\n{Color.Orange}Mapeadores: {Color.White}DragonZafiro, Elorreli, amirab, JamesT85," +
            $"\nTheYoungCapone, B4MB1[MC], Sleyer, mihaibr," +
            $"\nUnuAlex, SpikY_, Niktia_Ruchkov, Amads," +
            $"\nSamarchai, haubitze, Ghost-X, Zniper, Dr.Pawno," +
            $"\nSENiOR, saawan, Risq, Famous, Leo." +
            $"\n" +
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

    [Command("rules", Shortcut = "rules")]
    private static void Rules(Player player)
    {
        new MessageDialog("Reglas",
            $"{Color.Yellow}1. {Color.White}No insultes a ningún jugador." +
            $"\n{Color.Yellow}2. {Color.White}Prohíbido el uso de Cheats/Mods/Hacks para tu ventaja {Color.Orange}[Castigo: /Ban]." +
            $"\n{Color.Yellow}3. {Color.White}No hagas Spam/Publicidad/Flood de otros servidores." +
            $"\n{Color.Yellow}4. {Color.White}Está prohíbido el uso de armas rápidas (micro-uzi, sawn-off, etc)." +
            $"\nSi vez que alguien no cumplen con las reglas pon {Color.Yellow}/report id razon", "Aceptar").Show(player);
    }

    [Command("infoadmin", Shortcut = "infoadmin")]
    private static void InfoAdmin(Player player)
    {
        new MessageDialog(" ",
            $"{Color.Yellow}¿Quieres formar parte del STAFF?" +
            $"\nCumple con estos 5 requerimientos:" +
            $"\n{Color.Orange}1-. {Color.White}Hacer 3 videos del servidor." +
            $"\n{Color.Orange}2-. {Color.White}Hacer 5 posts de taringa del servidor." +
            $"\n{Color.Orange}3-. {Color.White}Hacer 2 blogs del servidor." +
            $"\n{Color.Orange}4-. {Color.White}Traer mínimo a 6 jugadores al servidor." +
            $"\n{Color.Orange}5-. {Color.White}Tener mínimo 100 kills." +
            $"\n{Color.Yellow}Si cumples con estos requerimientos, tendrás un puesto asegurado en el STAFF.", "Aceptar").Show(player);
    }
}
