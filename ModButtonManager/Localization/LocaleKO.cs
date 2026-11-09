using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocaleKO : Locale
    {
        public LocaleKO(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "일반" },
            { "Layout", "배치" },
            { "Mod buttons", "모드 버튼" },
            { "Reset", "초기화" },
            { "About", "정보" },
            { "Below", "아래" },
            { "Right", "오른쪽" },
            { "Left", "왼쪽" },
            { "One button for all", "버튼 하나로 통합" },
            { "Separate left and right buttons", "왼쪽과 오른쪽 버튼 분리" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "왼쪽 모드 버튼" },
            { "Mod buttons — right", "오른쪽 모드 버튼" },
            { "Launcher buttons", "모음 버튼" },
            { "One button", "버튼 하나" },
            { "Left / right", "왼쪽 / 오른쪽" },
            { "Select buttons", "버튼 선택" },
            { "Finish selection", "선택 완료" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "선택 모드에서는 모드 버튼을 마우스 오른쪽 버튼으로 클릭합니다. 제외한 버튼은 원래 게임 UI로 돌아가며, 관리자에는 불투명도 40%의 미리보기가 남습니다. 선택을 끝내려면 옵션에서 ‘버튼 숨기기’를 끄세요. 이 모음 버튼을 마우스 오른쪽 버튼으로 클릭하면 설정이 열립니다. 마우스 왼쪽 버튼을 누른 채 아이콘을 끌어 순서를 바꿀 수 있습니다. 순서는 자동으로 저장되며 새 모드 버튼은 맨 뒤에 추가됩니다." },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "클릭하여 열기 또는 닫기 · 열린 상태 유지 · 오른쪽 클릭으로 설정 · 드래그하여 이동" },
            { "Dock settings", "독 설정" },
            { "Close", "닫기" },
            { "Group buttons", "버튼 모으기" },
            { "Lock launcher positions", "모음 버튼 위치 잠금" },
            { "Hide buttons (selection mode)", "버튼 숨기기(선택 모드)" },
            { "Opening direction", "열리는 방향" },
            { "Rows", "행 수" },
            { "Also include top left", "왼쪽 위도 포함" },
            { "Buttons in the dock", "독에 있는 버튼" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "‘버튼 숨기기’를 켜면 이 목록을 편집하거나 아이콘을 마우스 오른쪽 버튼으로 클릭할 수 있습니다. 제외한 버튼은 기본 게임 UI에 표시됩니다. 이 옵션을 끄면 관리자에서 불투명도 40%의 미리보기가 사라집니다. 마우스 왼쪽 버튼을 누른 채 아이콘을 끌어 순서를 바꿀 수 있습니다. 순서는 자동으로 저장되며 새 모드 버튼은 맨 뒤에 추가됩니다." },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "지원되는 모드 버튼을 찾을 수 없습니다. 각 모드의 버튼 표시 옵션을 켜세요." },
            { "The shared mod UI hook is unavailable in this game version.", "이 게임 버전에서는 공용 모드 UI 연결 기능을 사용할 수 없습니다." },
            { "Cannot safely position this button (transformed parent).", "상위 요소에 변환이 적용되어 이 버튼을 안전하게 배치할 수 없습니다." },
            { "Reset dock", "독 초기화" },
            { "Collected buttons", "모은 버튼" },
            { "Previous page", "이전 페이지" },
            { "Next page", "다음 페이지" },
            { "Mod button", "모드 버튼" },
            { "Version", "버전" },
            { "Installed Mod Button Manager version.", "설치된 Mod Button Manager 버전입니다." },
            { "Group mod buttons", "모드 버튼 모으기" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "왼쪽 위와 오른쪽 위에서 선택한 모드 버튼을 모읍니다. 끄면 각 버튼이 원래 위치로 돌아갑니다." },
            { "Combined launcher opening direction", "통합 모음 버튼이 열리는 방향" },
            { "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.", "독 버튼의 아래, 위, 오른쪽 또는 왼쪽으로 열립니다. 공간이 부족하면 화면에서 여유가 있는 방향으로 열립니다." },
            { "Left launcher opening direction", "왼쪽 모음 버튼이 열리는 방향" },
            { "Opening direction of the left launcher in separate mode.", "분리 모드에서 왼쪽 모음 버튼이 열리는 방향입니다." },
            { "Right launcher opening direction", "오른쪽 모음 버튼이 열리는 방향" },
            { "Opening direction of the right launcher in separate mode.", "분리 모드에서 오른쪽 모음 버튼이 열리는 방향입니다." },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "모든 모음 버튼을 끌어 이동할 수 없게 합니다. 열고 닫는 기능은 그대로 사용할 수 있습니다." },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "켜면 관리자에서 버튼을 마우스 오른쪽 버튼으로 클릭해 제외할 수 있습니다. 제외한 버튼은 게임 UI로 돌아가며, 관리자에는 불투명도 40%의 미리보기가 남습니다. 끄면 미리보기가 사라지고 선택이 완료됩니다." },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "모드 버튼을 하나의 모음 버튼에 넣거나 왼쪽과 오른쪽으로 나눕니다. 각 위치는 별도로 저장됩니다." },
            { "Arrange collected buttons in 1 to 10 rows. Large collections use pages.", "모은 버튼을 1~10행으로 배치합니다. 버튼이 많으면 여러 페이지로 나눕니다." },
            { "Also collect top-left mod buttons", "왼쪽 위 모드 버튼도 모으기" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "선택 사항입니다. 공용 모드 UI에 연결된 작은 버튼만 모으며 큰 패널은 제외합니다." },
            { "Restore the position, layout and button selection. Does not change other mods.", "위치, 배치 및 버튼 선택을 초기화합니다. 다른 모드의 설정에는 영향을 주지 않습니다." },
            { "Show button count", "버튼 개수 표시" },
            { "Show the number of collected mod buttons on the launcher buttons.", "모음 버튼에 모은 모드 버튼의 개수를 표시합니다." },
            { "Above", "위" },
        };
    }
}
