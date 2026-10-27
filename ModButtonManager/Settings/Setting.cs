using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;

namespace ModButtonManager.Settings
{
    public enum DockDirection { Below, Right, Left, Above }
    public enum ButtonGrouping { Combined, Separate }

    [FileLocation(nameof(ModButtonManager))]
    [SettingsUITabOrder(GeneralTab)]
    [SettingsUIGroupOrder(LayoutGroup, ResetGroup, AboutGroup)]
    [SettingsUIShowGroupName(LayoutGroup, ResetGroup, AboutGroup)]
    public sealed class Setting : ModSetting
    {
        public const string GeneralTab = "General";
        public const string LayoutGroup = "Layout";
        public const string SourcesGroup = "Sources";
        public const string ResetGroup = "Reset";
        public const string AboutGroup = "About";

        [SettingsUISection(GeneralTab, AboutGroup)]
        public string ModVersion => Mod.Version;
        public Setting(IMod mod) : base(mod) { SetDefaults(); }

        [SettingsUISection(GeneralTab, LayoutGroup)]
        public bool EnableDock { get; set; }

        [SettingsUISection(GeneralTab, LayoutGroup)]
        public ButtonGrouping Grouping { get; set; }

        [SettingsUISection(GeneralTab, LayoutGroup)]
        public DockDirection Direction { get; set; }

        [SettingsUISection(GeneralTab, LayoutGroup)]
        public DockDirection LeftDirection { get; set; }
        [SettingsUISection(GeneralTab, LayoutGroup)]
        public DockDirection RightDirection { get; set; }
        [SettingsUISection(GeneralTab, LayoutGroup)]
        public bool LockPositions { get; set; }
        [SettingsUISection(GeneralTab, LayoutGroup)]
        public bool EditButtonVisibility { get; set; }

        [SettingsUISection(GeneralTab, LayoutGroup)]
        public bool ShowButtonCount { get; set; }

        // Legacy switch is retained only for saved-settings compatibility.
        [SettingsUIHidden]
        public bool EnableExclusions { get; set; }

        [SettingsUISlider(min = 1, max = 10, step = 1, scalarMultiplier = 1)]
        [SettingsUISection(GeneralTab, LayoutGroup)]
        public int Rows { get; set; }


        [SettingsUIHidden]
        public bool IncludeTopLeft { get; set; }

        [SettingsUIHidden]
        public int PositionX { get; set; }
        [SettingsUIHidden]
        public int PositionY { get; set; }
        [SettingsUIHidden]
        public int LeftPositionX { get; set; }
        [SettingsUIHidden]
        public int LeftPositionY { get; set; }
        [SettingsUIHidden]
        public int RightPositionX { get; set; }
        [SettingsUIHidden]
        public int RightPositionY { get; set; }
        [SettingsUIHidden]
        public bool CombinedOpen { get; set; }
        [SettingsUIHidden]
        public bool LeftOpen { get; set; }
        [SettingsUIHidden]
        public bool RightOpen { get; set; }
        [SettingsUIHidden]
        public string ExcludedButtons { get; set; }

        [SettingsUIHidden]
        public string ButtonOrder { get; set; }
        [SettingsUIHidden]
        public string LeftButtonOrder { get; set; }
        [SettingsUIHidden]
        public string RightButtonOrder { get; set; }

        [SettingsUIButton]
        [SettingsUISection(GeneralTab, ResetGroup)]
        public bool ResetDock
        {
            set { SetDefaults(); ApplyAndSave(); }
        }

        public override void SetDefaults()
        {
            EnableDock = true;
            Grouping = ButtonGrouping.Combined;
            Direction = DockDirection.Below;
            LeftDirection = DockDirection.Right;
            RightDirection = DockDirection.Left;
            LockPositions = false;
            EnableExclusions = true;
            EditButtonVisibility = false;
            Rows = 1;
            ShowButtonCount = true;
            IncludeTopLeft = true;
            PositionX = 840;
            PositionY = 85;
            LeftPositionX = 10;
            LeftPositionY = 85;
            RightPositionX = 960;
            RightPositionY = 85;
            CombinedOpen = false;
            LeftOpen = false;
            RightOpen = false;
            ExcludedButtons = string.Empty;
            ButtonOrder = LeftButtonOrder = RightButtonOrder = string.Empty;
        }
    }
}
