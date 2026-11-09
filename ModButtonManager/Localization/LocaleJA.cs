using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocaleJA : Locale
    {
        public LocaleJA(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "一般" },
            { "Layout", "レイアウト" },
            { "Mod buttons", "MODボタン" },
            { "Reset", "リセット" },
            { "About", "情報" },
            { "Below", "下" },
            { "Right", "右" },
            { "Left", "左" },
            { "One button for all", "1つにまとめる" },
            { "Separate left and right buttons", "左右別々のボタン" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "左側のMODボタン" },
            { "Mod buttons — right", "右側のMODボタン" },
            { "Launcher buttons", "まとめボタン" },
            { "One button", "1つのボタン" },
            { "Left / right", "左／右" },
            { "Select buttons", "ボタンを選択" },
            { "Finish selection", "選択を終了" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "選択モードではMODボタンを右クリックします。除外したボタンは元のゲームUIに戻り、マネージャーには不透明度40%のプレビューが残ります。終了するにはオプションで「ボタンを非表示」をオフにします。このまとめボタンを右クリックすると設定が開きます。マウスの左ボタンを押したままアイコンをドラッグすると並べ替えられます。順序は自動で保存され、新しいMODボタンは末尾に追加されます。" },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "クリックで開閉 · 開いたまま保持 · 右クリックで設定 · ドラッグで移動" },
            { "Dock settings", "ドック設定" },
            { "Close", "閉じる" },
            { "Group buttons", "ボタンをまとめる" },
            { "Lock launcher positions", "まとめボタンの位置を固定" },
            { "Hide buttons (selection mode)", "ボタンを非表示（選択モード）" },
            { "Opening direction", "開く方向" },
            { "Rows", "行数" },
            { "Also include top left", "左上も対象にする" },
            { "Buttons in the dock", "ドック内のボタン" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "「ボタンを非表示」をオンにすると、この一覧を編集したり、アイコンを右クリックしたりできます。除外したボタンは通常のゲームUIに表示されます。オフにすると、マネージャーから不透明度40%のプレビューが消えます。マウスの左ボタンを押したままアイコンをドラッグすると並べ替えられます。順序は自動で保存され、新しいMODボタンは末尾に追加されます。" },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "対応するMODボタンが見つかりません。各MODのボタン表示設定をオンにしてください。" },
            { "The shared mod UI hook is unavailable in this game version.", "このゲームバージョンでは共通のMOD UIフックを利用できません。" },
            { "Cannot safely position this button (transformed parent).", "親要素に変形が適用されているため、このボタンを安全に配置できません。" },
            { "Reset dock", "ドックをリセット" },
            { "Collected buttons", "まとめたボタン" },
            { "Previous page", "前のページ" },
            { "Next page", "次のページ" },
            { "Mod button", "MODボタン" },
            { "Version", "バージョン" },
            { "Installed Mod Button Manager version.", "インストール済みのMod Button Managerのバージョンです。" },
            { "Group mod buttons", "MODボタンをまとめる" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "左上と右上の選択したMODボタンをまとめます。オフにすると元の位置に戻ります。" },
            { "Combined launcher opening direction", "共通のまとめボタンが開く方向" },
            { "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.", "ドックボタンの下、上、右、左のいずれかに開きます。スペースが足りない場合は、画面内の空いている方向に開きます。" },
            { "Left launcher opening direction", "左のまとめボタンが開く方向" },
            { "Opening direction of the left launcher in separate mode.", "左右を分けたときに、左のまとめボタンが開く方向です。" },
            { "Right launcher opening direction", "右のまとめボタンが開く方向" },
            { "Opening direction of the right launcher in separate mode.", "左右を分けたときに、右のまとめボタンが開く方向です。" },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "すべてのまとめボタンをドラッグで移動できなくします。開閉は引き続き可能です。" },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "オンにすると、マネージャー内のボタンを右クリックで除外できます。除外したボタンはゲームUIに戻り、マネージャーには不透明度40%のプレビューが残ります。オフにするとプレビューが消え、選択を終了します。" },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "すべてのMODボタンを1つにまとめるか、左右に分けます。それぞれの位置は個別に保存されます。" },
            { "Arrange collected buttons in 1 to 10 rows. Large collections use pages.", "まとめたボタンを1〜10行に並べます。ボタンが多い場合は複数ページに分かれます。" },
            { "Also collect top-left mod buttons", "左上のMODボタンもまとめる" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "任意の設定です。共通のMOD UIフックにある小さなボタンだけを対象にします。大きなパネルは除外されます。" },
            { "Restore the position, layout and button selection. Does not change other mods.", "位置、レイアウト、ボタンの選択を初期状態に戻します。他のMODの設定には影響しません。" },
            { "Show button count", "ボタン数を表示" },
            { "Show the number of collected mod buttons on the launcher buttons.", "まとめボタンに、まとめたMODボタンの数を表示します。" },
            { "Above", "上" },
        };
    }
}
