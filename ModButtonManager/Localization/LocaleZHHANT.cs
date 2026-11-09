using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocaleZHHANT : Locale
    {
        public LocaleZHHANT(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "一般" },
            { "Layout", "版面配置" },
            { "Mod buttons", "模組按鈕" },
            { "Reset", "重設" },
            { "About", "關於" },
            { "Below", "向下" },
            { "Right", "向右" },
            { "Left", "向左" },
            { "One button for all", "共用一個按鈕" },
            { "Separate left and right buttons", "左右分開使用按鈕" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "左側模組按鈕" },
            { "Mod buttons — right", "右側模組按鈕" },
            { "Launcher buttons", "群組按鈕" },
            { "One button", "一個按鈕" },
            { "Left / right", "左側 / 右側" },
            { "Select buttons", "選取按鈕" },
            { "Finish selection", "完成選取" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "在選取模式下，按一下滑鼠右鍵即可排除模組按鈕。已排除的按鈕會回到原本的遊戲介面，管理員中會保留不透明度為 40% 的預覽。若要完成選取，請在選項中關閉「隱藏按鈕」。在此群組按鈕上按一下滑鼠右鍵可開啟設定。按住滑鼠左鍵並拖曳圖示即可重新排序。順序會自動儲存，新的模組按鈕會加在最後。" },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "按一下可展開或收合 · 保持展開 · 按右鍵開啟設定 · 拖曳可移動" },
            { "Dock settings", "按鈕列設定" },
            { "Close", "關閉" },
            { "Group buttons", "將按鈕分組" },
            { "Lock launcher positions", "鎖定群組按鈕位置" },
            { "Hide buttons (selection mode)", "隱藏按鈕（選取模式）" },
            { "Opening direction", "展開方向" },
            { "Rows", "列數" },
            { "Also include top left", "也納入左上角按鈕" },
            { "Buttons in the dock", "按鈕列中的按鈕" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "啟用「隱藏按鈕」後，可以編輯此清單或在圖示上按一下滑鼠右鍵。已排除的按鈕會保留在一般遊戲介面中。關閉此選項後，管理員中不透明度為 40% 的預覽會消失。按住滑鼠左鍵並拖曳圖示即可重新排序。順序會自動儲存，新的模組按鈕會加在最後。" },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "找不到支援的模組按鈕。請在對應模組的選項中啟用按鈕顯示。" },
            { "The shared mod UI hook is unavailable in this game version.", "此遊戲版本無法使用共用的模組介面掛接點。" },
            { "Cannot safely position this button (transformed parent).", "上層元素已套用轉換，無法安全放置此按鈕。" },
            { "Reset dock", "重設按鈕列" },
            { "Collected buttons", "已分組的按鈕" },
            { "Previous page", "上一頁" },
            { "Next page", "下一頁" },
            { "Mod button", "模組按鈕" },
            { "Version", "版本" },
            { "Installed Mod Button Manager version.", "已安裝的 Mod Button Manager 版本。" },
            { "Group mod buttons", "將模組按鈕分組" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "將左上角和右上角選取的模組按鈕分組。關閉後，各按鈕會回到原來的位置。" },
            { "Combined launcher opening direction", "共用群組按鈕的展開方向" },
            { "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.", "按鈕列可在群組按鈕的下方、上方、右側或左側展開。空間不足時，會改用畫面上有空間的一側。" },
            { "Left launcher opening direction", "左側群組按鈕的展開方向" },
            { "Opening direction of the left launcher in separate mode.", "左右分開時，左側群組按鈕的展開方向。" },
            { "Right launcher opening direction", "右側群組按鈕的展開方向" },
            { "Opening direction of the right launcher in separate mode.", "左右分開時，右側群組按鈕的展開方向。" },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "鎖定所有群組按鈕，使其無法拖曳移動。仍可展開和收合按鈕列。" },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "啟用後，可以在管理員中按滑鼠右鍵來排除按鈕。已排除的按鈕會回到遊戲介面，管理員中會保留不透明度為 40% 的預覽。關閉此選項即可隱藏預覽並完成選取。" },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "用一個群組按鈕管理所有模組按鈕，或在左右兩側分別使用群組按鈕。各按鈕的位置會分別儲存。" },
            { "Arrange collected buttons in 1 to 10 rows. Large collections use pages.", "將群組內的按鈕排成 1 至 10 列。按鈕較多時會分頁顯示。" },
            { "Also collect top-left mod buttons", "也將左上角的模組按鈕分組" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "選用設定。只將共用模組介面掛接點中的小型按鈕分組，大型面板會排除。" },
            { "Restore the position, layout and button selection. Does not change other mods.", "還原按鈕列的位置、版面配置和按鈕選取。其他模組的設定會保留。" },
            { "Show button count", "顯示按鈕數量" },
            { "Show the number of collected mod buttons on the launcher buttons.", "在群組按鈕上顯示該群組內的模組按鈕數量。" },
            { "Above", "向上" },
        };
    }
}
