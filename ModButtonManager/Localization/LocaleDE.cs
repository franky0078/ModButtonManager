using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocaleDE : Locale
    {
        public LocaleDE(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "Allgemein" },
            { "Layout", "Anordnung" },
            { "Mod buttons", "Mod-Buttons" },
            { "Reset", "Zurücksetzen" },
            { "About", "Informationen" },
            { "Below", "Darunter" },
            { "Right", "Rechts" },
            { "Left", "Links" },
            { "One button for all", "Ein Button für alle" },
            { "Separate left and right buttons", "Links und rechts getrennt" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "Mod-Buttons links" },
            { "Mod buttons — right", "Mod-Buttons rechts" },
            { "Launcher buttons", "Sammelbuttons" },
            { "One button", "Ein Button" },
            { "Left / right", "Links / rechts" },
            { "Select buttons", "Buttons auswählen" },
            { "Finish selection", "Auswahl beenden" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings.", "Auswahlmodus: Mod-Buttons per Rechtsklick ausschließen. Originale kehren in die Spiel-UI zurück; Vorschauen im Manager haben 40 % Deckkraft. Zum Beenden Ausblenden in den Optionen ausschalten. Rechtsklick auf diesen Sammelbutton öffnet die Einstellungen." },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "Klick zum Auf- oder Einklappen · Bleibt geöffnet · Rechtsklick für Einstellungen · Ziehen zum Verschieben" },
            { "Dock settings", "Dock-Einstellungen" },
            { "Close", "Schließen" },
            { "Group buttons", "Buttons zusammenfassen" },
            { "Lock launcher positions", "Positionen der Sammelbuttons sperren" },
            { "Hide buttons (selection mode)", "Ausblenden (Auswahlmodus)" },
            { "Opening direction", "Aufklapprichtung" },
            { "Rows", "Reihen" },
            { "Also include top left", "Oben links ebenfalls erfassen" },
            { "Buttons in the dock", "Buttons im Dock" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager.", "Ausblenden aktivieren, um die Liste oder die Symbole per Rechtsklick zu bearbeiten. Ausgeschlossene Buttons bleiben in der normalen Spiel-UI. Ausschalten entfernt ihre Vorschauen mit 40 % Deckkraft aus dem Manager." },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "Keine unterstützten Mod-Buttons gefunden. Ihre eigenen Startbutton-Optionen müssen eingeschaltet sein." },
            { "The shared mod UI hook is unavailable in this game version.", "Der gemeinsame Mod-UI-Einhängepunkt ist in dieser Spielversion nicht verfügbar." },
            { "Cannot safely position this button (transformed parent).", "Dieser Button kann nicht sicher positioniert werden (transformiertes übergeordnetes Element)." },
            { "Reset dock", "Dock zurücksetzen" },
            { "Collected buttons", "Zusammengefasste Buttons" },
            { "Previous page", "Vorherige Seite" },
            { "Next page", "Nächste Seite" },
            { "Mod button", "Mod-Button" },
            { "Version", "Version" },
            { "Installed Mod Button Manager version.", "Installierte Version von Mod Button Manager." },
            { "Group mod buttons", "Mod-Buttons zusammenfassen" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "Fasst ausgewählte Mod-Buttons oben links und rechts zusammen. Ausschalten stellt die ursprünglichen Positionen wieder her." },
            { "Combined launcher opening direction", "Aufklapprichtung gemeinsamer Button" },
            { "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.", "Öffnet die Leiste unterhalb, oberhalb, rechts oder links vom Sammelbutton. Weicht bei Bedarf auf verfügbaren Bildschirmplatz aus." },
            { "Left launcher opening direction", "Aufklapprichtung links" },
            { "Opening direction of the left launcher in separate mode.", "Aufklapprichtung des linken Sammelbuttons bei getrennten Seiten." },
            { "Right launcher opening direction", "Aufklapprichtung rechts" },
            { "Opening direction of the right launcher in separate mode.", "Aufklapprichtung des rechten Sammelbuttons bei getrennten Seiten." },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "Verhindert das Verschieben aller Sammelbuttons. Auf- und Einklappen bleibt möglich." },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "Aktivieren, dann Buttons im Manager per Rechtsklick ausschließen. Originalbuttons kehren in die Spiel-UI zurück; im Manager bleiben Vorschauen mit 40 % Deckkraft. Ausschalten beendet die Auswahl und entfernt die Vorschauen." },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "Ein gemeinsamer Button für alle Mod-Buttons oder getrennte Sammelbuttons für links und rechts. Positionen werden getrennt gespeichert." },
            { "Arrange collected buttons in 1 to 10 rows. Large collections use pages.", "Ordnet die Buttons in 1 bis 10 Reihen an. Große Sammlungen werden auf Seiten verteilt." },
            { "Also collect top-left mod buttons", "Auch Mod-Buttons oben links erfassen" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "Optional. Erfasst kleine Startbuttons an den gemeinsamen Mod-UI-Einhängepunkten; große Fenster werden ausgeschlossen." },
            { "Restore the position, layout and button selection. Does not change other mods.", "Setzt Position, Anordnung und Buttonauswahl zurück. Andere Mods werden nicht umgestellt." },
            { "Show button count", "Anzahl der Buttons anzeigen" },
            { "Show the number of collected mod buttons on the launcher buttons.", "Zeigt die Anzahl der zusammengefassten Mod-Buttons auf den Sammelbuttons an." },
            { "Above", "Nach oben" },
        };
    }
}
