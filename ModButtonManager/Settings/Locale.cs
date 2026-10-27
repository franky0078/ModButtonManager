using Colossal;
using System.Collections.Generic;

namespace ModButtonManager.Settings
{
    public abstract class Locale : IDictionarySource
    {
        private readonly Setting m_Setting;
        private readonly Dictionary<string, string> m_Texts;
        protected Locale(Setting setting, Dictionary<string, string> texts) { m_Setting = setting; m_Texts = texts; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            var entries = new Dictionary<string, string>();
            entries[m_Setting.GetSettingsLocaleID()] = "Mod Button Manager";
            entries[m_Setting.GetOptionTabLocaleID(Setting.GeneralTab)] = Text("General");
            entries[m_Setting.GetOptionGroupLocaleID(Setting.LayoutGroup)] = Text("Layout");
            entries[m_Setting.GetOptionGroupLocaleID(Setting.SourcesGroup)] = Text("Mod buttons");
            entries[m_Setting.GetOptionGroupLocaleID(Setting.ResetGroup)] = Text("Reset");
            entries[m_Setting.GetOptionGroupLocaleID(Setting.AboutGroup)] = Text("About");
            Option(entries, nameof(Setting.ModVersion), "Version",
                "Installed Mod Button Manager version.");
            Option(entries, nameof(Setting.EnableDock), "Group mod buttons",
                "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.");
            Option(entries, nameof(Setting.Direction), "Combined launcher opening direction",
                "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.");
            Option(entries, nameof(Setting.LeftDirection), "Left launcher opening direction",
                "Opening direction of the left launcher in separate mode.");
            Option(entries, nameof(Setting.RightDirection), "Right launcher opening direction",
                "Opening direction of the right launcher in separate mode.");
            Option(entries, nameof(Setting.LockPositions), "Lock launcher positions",
                "Prevent dragging all launcher buttons. Opening and closing remains available.");
            Option(entries, nameof(Setting.EditButtonVisibility), "Hide buttons (selection mode)",
                "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.");
            Option(entries, nameof(Setting.Grouping), "Launcher buttons",
                "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.");
            Option(entries, nameof(Setting.ShowButtonCount), "Show button count",
                "Show the number of collected mod buttons on the launcher buttons.");
            Option(entries, nameof(Setting.Rows), "Rows",
                "Arrange collected buttons in 1 to 10 rows. Large collections use pages.");
            Option(entries, nameof(Setting.IncludeTopLeft), "Also collect top-left mod buttons",
                "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.");
            Option(entries, nameof(Setting.ResetDock), "Reset dock",
                "Restore the position, layout and button selection. Does not change other mods.");
            entries[m_Setting.GetEnumValueLocaleID(DockDirection.Below)] = Text("Below");
            entries[m_Setting.GetEnumValueLocaleID(DockDirection.Right)] = Text("Right");
            entries[m_Setting.GetEnumValueLocaleID(DockDirection.Left)] = Text("Left");
            entries[m_Setting.GetEnumValueLocaleID(DockDirection.Above)] = Text("Above");
            entries[m_Setting.GetEnumValueLocaleID(ButtonGrouping.Combined)] = Text("One button for all");
            entries[m_Setting.GetEnumValueLocaleID(ButtonGrouping.Separate)] = Text("Separate left and right buttons");
            UI(entries, "Title", "Mod Button Manager");
            UI(entries, "LeftLauncher", "Mod buttons — left");
            UI(entries, "RightLauncher", "Mod buttons — right");
            UI(entries, "Grouping", "Launcher buttons");
            UI(entries, "Combined", "One button");
            UI(entries, "Separate", "Left / right");
            UI(entries, "SelectButtons", "Select buttons");
            UI(entries, "FinishSelection", "Finish selection");
            UI(entries, "SelectHint", "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.");
            UI(entries, "Toggle", "Click to open or close · Stays open · Right-click for settings · Drag to move");
            UI(entries, "Settings", "Dock settings");
            UI(entries, "Close", "Close");
            UI(entries, "Enabled", "Group buttons");
            UI(entries, "Locked", "Lock launcher positions");
            UI(entries, "EditVisibility", "Hide buttons (selection mode)");
            UI(entries, "Direction", "Opening direction");
            UI(entries, "Below", "Below");
            UI(entries, "Above", "Above");
            UI(entries, "Right", "Right");
            UI(entries, "Left", "Left");
            UI(entries, "Rows", "Rows");
            UI(entries, "ShowButtonCount", "Show button count");
            UI(entries, "TopLeft", "Also include top left");
            UI(entries, "Selection", "Buttons in the dock");
            UI(entries, "SelectionHint", "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.");
            UI(entries, "Empty", "No supported mod buttons found. Their own launcher options must be enabled.");
            UI(entries, "Unavailable", "The shared mod UI hook is unavailable in this game version.");
            UI(entries, "Unsupported", "Cannot safely position this button (transformed parent).");
            UI(entries, "Reset", "Reset dock");
            UI(entries, "Count", "Collected buttons");
            UI(entries, "Previous", "Previous page");
            UI(entries, "Next", "Next page");
            UI(entries, "Generic", "Mod button");
            return entries;
        }

        private string Text(string english) => m_Texts.TryGetValue(english, out var value) ? value : english;
        private void UI(Dictionary<string, string> entries, string key, string english)
            => entries["ModButtonManager.UI." + key] = Text(english);
        private void Option(Dictionary<string, string> entries, string property,
            string english, string englishDescription)
        {
            entries[m_Setting.GetOptionLabelLocaleID(property)] = Text(english);
            entries[m_Setting.GetOptionDescLocaleID(property)] = Text(englishDescription);
        }
        public void Unload() { }
    }
}
