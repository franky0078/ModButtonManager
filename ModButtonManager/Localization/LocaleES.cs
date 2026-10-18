using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocaleES : Locale
    {
        public LocaleES(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "General" },
            { "Layout", "Distribución" },
            { "Mod buttons", "Botones de mods" },
            { "Reset", "Restablecer" },
            { "About", "Información" },
            { "Below", "Debajo" },
            { "Right", "A la derecha" },
            { "Left", "A la izquierda" },
            { "One button for all", "Un botón para todos" },
            { "Separate left and right buttons", "Botones separados a izquierda y derecha" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "Botones de mods — izquierda" },
            { "Mod buttons — right", "Botones de mods — derecha" },
            { "Launcher buttons", "Botones de agrupación" },
            { "One button", "Un botón" },
            { "Left / right", "Izquierda / derecha" },
            { "Select buttons", "Seleccionar botones" },
            { "Finish selection", "Terminar selección" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings.", "Modo de selección: clic derecho en los botones de mods. Los originales excluidos vuelven a la interfaz del juego; sus vistas previas en el gestor tienen un 40 % de opacidad. Desactiva Ocultar botones en las opciones para terminar. Haz clic derecho en este botón para abrir los ajustes." },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "Clic para abrir o cerrar · Permanece abierto · Clic derecho para los ajustes · Arrastrar para mover" },
            { "Dock settings", "Ajustes del gestor" },
            { "Close", "Cerrar" },
            { "Group buttons", "Agrupar botones" },
            { "Lock launcher positions", "Bloquear las posiciones de los botones de agrupación" },
            { "Hide buttons (selection mode)", "Ocultar botones (modo de selección)" },
            { "Opening direction", "Dirección de apertura" },
            { "Rows", "Filas" },
            { "Also include top left", "Incluir también los botones de arriba a la izquierda" },
            { "Buttons in the dock", "Botones en el gestor" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager.", "Activa Ocultar botones para editar esta lista o hacer clic derecho en los iconos. Los botones excluidos permanecen en la interfaz normal del juego. Desactiva la opción para quitar del gestor sus vistas previas con un 40 % de opacidad." },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "No se han encontrado botones de mods compatibles. Debe estar activada la opción para mostrar el botón en cada mod." },
            { "The shared mod UI hook is unavailable in this game version.", "El punto de integración común de los mods no está disponible en esta versión del juego." },
            { "Cannot safely position this button (transformed parent).", "No se puede colocar este botón de forma segura (elemento padre transformado)." },
            { "Reset dock", "Restablecer gestor" },
            { "Collected buttons", "Botones agrupados" },
            { "Previous page", "Página anterior" },
            { "Next page", "Página siguiente" },
            { "Mod button", "Botón de mod" },
            { "Version", "Versión" },
            { "Installed Mod Button Manager version.", "Versión instalada de Mod Button Manager." },
            { "Group mod buttons", "Agrupar botones de mods" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "Agrupa los botones de mods seleccionados de arriba a la izquierda y a la derecha. Desactiva la opción para restaurar sus posiciones originales." },
            { "Combined launcher opening direction", "Dirección de apertura del botón común" },
            { "Open below, to the right or to the left of the dock button. Falls back below if there is no space beside it.", "Abre la barra debajo, a la derecha o a la izquierda del botón. Si no hay espacio lateral suficiente, se abre debajo." },
            { "Left launcher opening direction", "Dirección de apertura a la izquierda" },
            { "Opening direction of the left launcher in separate mode.", "Dirección de apertura del botón de agrupación izquierdo en el modo separado." },
            { "Right launcher opening direction", "Dirección de apertura a la derecha" },
            { "Opening direction of the right launcher in separate mode.", "Dirección de apertura del botón de agrupación derecho en el modo separado." },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "Impide arrastrar todos los botones de agrupación. Se pueden seguir abriendo y cerrando." },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "Activa la opción para seleccionar botones del gestor con el clic derecho. Los originales excluidos vuelven a la interfaz del juego; sus vistas previas con un 40 % de opacidad permanecen en el gestor. Desactiva la opción para quitar las vistas previas y terminar." },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "Usa un botón común para todos los mods o botones separados a izquierda y derecha. Cada posición se guarda por separado." },
            { "Arrange collected buttons in one, two or three rows. Large collections use pages.", "Organiza los botones agrupados en una, dos o tres filas. Las colecciones grandes se distribuyen en varias páginas." },
            { "Also collect top-left mod buttons", "Agrupar también los botones de mods de arriba a la izquierda" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "Opcional. Solo agrupa los botones pequeños de los puntos de integración comunes de los mods; las ventanas grandes se excluyen." },
            { "Restore the position, layout and button selection. Does not change other mods.", "Restablece posiciones, distribución y selección de botones. No modifica los demás mods." },
        };
    }
}
