using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocaleZHHANS : Locale
    {
        public LocaleZHHANS(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "常规" },
            { "Layout", "布局" },
            { "Mod buttons", "模组按钮" },
            { "Reset", "重置" },
            { "About", "关于" },
            { "Below", "向下" },
            { "Right", "向右" },
            { "Left", "向左" },
            { "One button for all", "合用一个按钮" },
            { "Separate left and right buttons", "左右分别使用按钮" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "左侧模组按钮" },
            { "Mod buttons — right", "右侧模组按钮" },
            { "Launcher buttons", "汇总按钮" },
            { "One button", "一个按钮" },
            { "Left / right", "左侧 / 右侧" },
            { "Select buttons", "选择按钮" },
            { "Finish selection", "完成选择" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "在选择模式下，右键单击模组按钮即可将其排除。被排除的按钮会回到原来的游戏界面，管理器中会保留不透明度为 40% 的预览。要完成选择，请在选项中关闭「隐藏按钮」。右键单击此汇总按钮可打开设置。按住鼠标左键并拖动图标即可重新排序。顺序会自动保存，新的模组按钮会添加到末尾。" },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "单击可展开或收起 · 保持展开 · 右键打开设置 · 拖动可移动" },
            { "Dock settings", "按钮栏设置" },
            { "Close", "关闭" },
            { "Group buttons", "汇总按钮" },
            { "Lock launcher positions", "锁定汇总按钮位置" },
            { "Hide buttons (selection mode)", "隐藏按钮（选择模式）" },
            { "Opening direction", "展开方向" },
            { "Rows", "行数" },
            { "Also include top left", "也纳入左上角按钮" },
            { "Buttons in the dock", "按钮栏中的按钮" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "启用「隐藏按钮」后，可以编辑此列表或右键单击图标。被排除的按钮会保留在常规游戏界面中。关闭此选项后，管理器中不透明度为 40% 的预览将消失。按住鼠标左键并拖动图标即可重新排序。顺序会自动保存，新的模组按钮会添加到末尾。" },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "未找到受支持的模组按钮。请在相应模组的选项中启用按钮显示。" },
            { "The shared mod UI hook is unavailable in this game version.", "此游戏版本无法使用共享的模组界面挂接点。" },
            { "Cannot safely position this button (transformed parent).", "父元素应用了变换，无法安全放置此按钮。" },
            { "Reset dock", "重置按钮栏" },
            { "Collected buttons", "已汇总的按钮" },
            { "Previous page", "上一页" },
            { "Next page", "下一页" },
            { "Mod button", "模组按钮" },
            { "Version", "版本" },
            { "Installed Mod Button Manager version.", "已安装的 Mod Button Manager 版本。" },
            { "Group mod buttons", "汇总模组按钮" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "汇总左上角和右上角选中的模组按钮。关闭后，各按钮将恢复到原来的位置。" },
            { "Combined launcher opening direction", "共用汇总按钮的展开方向" },
            { "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.", "按钮栏可在汇总按钮的下方、上方、右侧或左侧展开。空间不足时，会改用屏幕上有空余空间的一侧。" },
            { "Left launcher opening direction", "左侧汇总按钮的展开方向" },
            { "Opening direction of the left launcher in separate mode.", "左右分开时，左侧汇总按钮的展开方向。" },
            { "Right launcher opening direction", "右侧汇总按钮的展开方向" },
            { "Opening direction of the right launcher in separate mode.", "左右分开时，右侧汇总按钮的展开方向。" },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "禁止拖动所有汇总按钮。仍可展开和收起按钮栏。" },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "启用后，可以在管理器中右键单击按钮以将其排除。被排除的按钮会回到游戏界面，管理器中会保留不透明度为 40% 的预览。关闭此选项可隐藏预览并完成选择。" },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "用一个汇总按钮管理所有模组按钮，或在左右两侧分别使用汇总按钮。各按钮的位置会单独保存。" },
            { "Arrange collected buttons in 1 to 10 rows. Large collections use pages.", "将汇总的按钮排列成 1 至 10 行。按钮较多时将分页显示。" },
            { "Also collect top-left mod buttons", "也汇总左上角的模组按钮" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "可选。只汇总共享模组界面挂接点中的小按钮，大型面板会被排除。" },
            { "Restore the position, layout and button selection. Does not change other mods.", "恢复按钮栏的位置、布局和按钮选择。其他模组的设置会保留。" },
            { "Show button count", "显示按钮数量" },
            { "Show the number of collected mod buttons on the launcher buttons.", "在汇总按钮上显示已汇总的模组按钮数量。" },
            { "Above", "向上" },
        };
    }
}
