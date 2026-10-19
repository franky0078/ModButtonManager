using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Colossal.UI.Binding;
using Game;
using Game.UI;
using ModButtonManager.Settings;

namespace ModButtonManager.Systems
{
    public partial class DockUISystem : UISystemBase
    {
        private const string Group = "modButtonManager";
        private static readonly Regex ButtonKey = new Regex(@"^[a-f0-9]{8}-[0-9]{1,4}$");
        public override GameMode gameMode => GameMode.Game;

        protected override void OnCreate()
        {
            base.OnCreate();
            AddUpdateBinding(new GetterValueBinding<bool>(Group, "enabled", () => Mod.Settings?.EnableDock ?? false));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "grouping", () => (int)(Mod.Settings?.Grouping ?? ButtonGrouping.Combined)));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "direction", () => (int)(Mod.Settings?.Direction ?? DockDirection.Below)));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "leftDirection", () => (int)(Mod.Settings?.LeftDirection ?? DockDirection.Right)));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "rightDirection", () => (int)(Mod.Settings?.RightDirection ?? DockDirection.Left)));
            AddUpdateBinding(new GetterValueBinding<bool>(Group, "locked", () => Mod.Settings?.LockPositions ?? false));
            AddUpdateBinding(new GetterValueBinding<bool>(Group, "editVisibility", () => Mod.Settings?.EditButtonVisibility ?? false));
            AddUpdateBinding(new GetterValueBinding<bool>(Group, "showButtonCount", () => Mod.Settings?.ShowButtonCount ?? true));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "rows", () => Mod.Settings?.Rows ?? 1));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "x", () => Mod.Settings?.PositionX ?? 840));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "y", () => Mod.Settings?.PositionY ?? 85));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "leftX", () => Mod.Settings?.LeftPositionX ?? 10));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "leftY", () => Mod.Settings?.LeftPositionY ?? 85));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "rightX", () => Mod.Settings?.RightPositionX ?? 960));
            AddUpdateBinding(new GetterValueBinding<int>(Group, "rightY", () => Mod.Settings?.RightPositionY ?? 85));
            AddUpdateBinding(new GetterValueBinding<bool>(Group, "open", () => Mod.Settings?.CombinedOpen ?? false));
            AddUpdateBinding(new GetterValueBinding<bool>(Group, "leftOpen", () => Mod.Settings?.LeftOpen ?? false));
            AddUpdateBinding(new GetterValueBinding<bool>(Group, "rightOpen", () => Mod.Settings?.RightOpen ?? false));
            AddUpdateBinding(new GetterValueBinding<string>(Group, "excluded", () => Mod.Settings?.ExcludedButtons ?? string.Empty));
            AddBinding(new TriggerBinding<string, string>(Group, "setOption", SetOption));
            AddBinding(new TriggerBinding<int, int>(Group, "position", SavePosition));
            AddBinding(new TriggerBinding<int, int>(Group, "positionLeft", (x, y) => SaveSidePosition(true, x, y)));
            AddBinding(new TriggerBinding<int, int>(Group, "positionRight", (x, y) => SaveSidePosition(false, x, y)));
            AddBinding(new TriggerBinding<string, bool>(Group, "include", IncludeButton));
            AddBinding(new TriggerBinding(Group, "reset", () =>
            {
                if (Mod.Settings == null) return;
                Mod.Settings.SetDefaults();
                Mod.Settings.ApplyAndSave();
            }));
        }

        private static int Clamp(int value, int min, int max) => Math.Max(min, Math.Min(max, value));

        private static void SetOption(string key, string value)
        {
            var settings = Mod.Settings;
            if (settings == null) return;
            if (key == "enabled" && bool.TryParse(value, out bool enabled)) settings.EnableDock = enabled;
            else if (key == "open" && bool.TryParse(value, out bool open)) settings.CombinedOpen = open;
            else if (key == "leftOpen" && bool.TryParse(value, out bool leftOpen)) settings.LeftOpen = leftOpen;
            else if (key == "rightOpen" && bool.TryParse(value, out bool rightOpen)) settings.RightOpen = rightOpen;
            else if (key == "grouping" && int.TryParse(value, out int grouping) && grouping >= 0 && grouping <= 1)
                settings.Grouping = (ButtonGrouping)grouping;
            else if (key == "direction" && int.TryParse(value, out int direction) && direction >= 0 && direction <= 3)
                settings.Direction = (DockDirection)direction;
            else if (key == "leftDirection" && int.TryParse(value, out int leftDirection) && leftDirection >= 0 && leftDirection <= 3)
                settings.LeftDirection = (DockDirection)leftDirection;
            else if (key == "rightDirection" && int.TryParse(value, out int rightDirection) && rightDirection >= 0 && rightDirection <= 3)
                settings.RightDirection = (DockDirection)rightDirection;
            else if (key == "locked" && bool.TryParse(value, out bool locked)) settings.LockPositions = locked;
            else if (key == "editVisibility" && bool.TryParse(value, out bool editVisibility)) settings.EditButtonVisibility = editVisibility;
            else if (key == "showButtonCount" && bool.TryParse(value, out bool showButtonCount)) settings.ShowButtonCount = showButtonCount;
            else if (key == "rows" && int.TryParse(value, out int rows) && rows >= 1 && rows <= 10) settings.Rows = rows;
            else return;
            settings.ApplyAndSave();
        }

        private static void SavePosition(int x, int y)
        {
            if (Mod.Settings == null || Mod.Settings.LockPositions) return;
            Mod.Settings.PositionX = Clamp(x, 0, 1000);
            Mod.Settings.PositionY = Clamp(y, 0, 1000);
            Mod.Settings.ApplyAndSave();
        }

        private static void SaveSidePosition(bool left, int x, int y)
        {
            if (Mod.Settings == null || Mod.Settings.LockPositions) return;
            if (left)
            {
                Mod.Settings.LeftPositionX = Clamp(x, 0, 1000);
                Mod.Settings.LeftPositionY = Clamp(y, 0, 1000);
            }
            else
            {
                Mod.Settings.RightPositionX = Clamp(x, 0, 1000);
                Mod.Settings.RightPositionY = Clamp(y, 0, 1000);
            }
            Mod.Settings.ApplyAndSave();
        }

        private static void IncludeButton(string key, bool include)
        {
            if (Mod.Settings == null || key == null || !ButtonKey.IsMatch(key)) return;
            var excluded = new HashSet<string>((Mod.Settings.ExcludedButtons ?? string.Empty)
                .Split('|').Where(id => ButtonKey.IsMatch(id)), StringComparer.Ordinal);
            if (include) excluded.Remove(key); else excluded.Add(key);
            Mod.Settings.ExcludedButtons = string.Join("|", excluded.OrderBy(id => id, StringComparer.Ordinal));
            Mod.Settings.ApplyAndSave();
        }
    }
}
