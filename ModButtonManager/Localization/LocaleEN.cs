using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocaleEN : Locale
    {
        public LocaleEN(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "General" },
            { "Layout", "Layout" },
            { "Mod buttons", "Mod buttons" },
            { "Reset", "Reset" },
            { "About", "About" },
            { "Below", "Below" },
            { "Right", "Right" },
            { "Left", "Left" },
            { "One button for all", "One button for all" },
            { "Separate left and right buttons", "Separate left and right buttons" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "Mod buttons — left" },
            { "Mod buttons — right", "Mod buttons — right" },
            { "Launcher buttons", "Launcher buttons" },
            { "One button", "One button" },
            { "Left / right", "Left / right" },
            { "Select buttons", "Select buttons" },
            { "Finish selection", "Finish selection" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings.", "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings." },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "Click to open or close · Stays open · Right-click for settings · Drag to move" },
            { "Dock settings", "Dock settings" },
            { "Close", "Close" },
            { "Group buttons", "Group buttons" },
            { "Lock launcher positions", "Lock launcher positions" },
            { "Hide buttons (selection mode)", "Hide buttons (selection mode)" },
            { "Opening direction", "Opening direction" },
            { "Rows", "Rows" },
            { "Also include top left", "Also include top left" },
            { "Buttons in the dock", "Buttons in the dock" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager.", "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager." },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "No supported mod buttons found. Their own launcher options must be enabled." },
            { "The shared mod UI hook is unavailable in this game version.", "The shared mod UI hook is unavailable in this game version." },
            { "Cannot safely position this button (transformed parent).", "Cannot safely position this button (transformed parent)." },
            { "Reset dock", "Reset dock" },
            { "Collected buttons", "Collected buttons" },
            { "Previous page", "Previous page" },
            { "Next page", "Next page" },
            { "Mod button", "Mod button" },
            { "Version", "Version" },
            { "Installed Mod Button Manager version.", "Installed Mod Button Manager version." },
            { "Group mod buttons", "Group mod buttons" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "Collect selected top-left and top-right mod buttons. Disable to restore their original positions." },
            { "Combined launcher opening direction", "Combined launcher opening direction" },
            { "Open below, to the right or to the left of the dock button. Falls back below if there is no space beside it.", "Open below, to the right or to the left of the dock button. Falls back below if there is no space beside it." },
            { "Left launcher opening direction", "Left launcher opening direction" },
            { "Opening direction of the left launcher in separate mode.", "Opening direction of the left launcher in separate mode." },
            { "Right launcher opening direction", "Right launcher opening direction" },
            { "Opening direction of the right launcher in separate mode.", "Opening direction of the right launcher in separate mode." },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "Prevent dragging all launcher buttons. Opening and closing remains available." },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection." },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately." },
            { "Arrange collected buttons in one or two rows. Large collections use pages.", "Arrange collected buttons in one or two rows. Large collections use pages." },
            { "Also collect top-left mod buttons", "Also collect top-left mod buttons" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded." },
            { "Restore the position, layout and button selection. Does not change other mods.", "Restore the position, layout and button selection. Does not change other mods." },
        };
    }
}
