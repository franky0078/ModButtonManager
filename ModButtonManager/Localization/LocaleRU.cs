using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocaleRU : Locale
    {
        public LocaleRU(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "Общие" },
            { "Layout", "Расположение" },
            { "Mod buttons", "Кнопки модов" },
            { "Reset", "Сброс" },
            { "About", "О моде" },
            { "Below", "Вниз" },
            { "Right", "Вправо" },
            { "Left", "Влево" },
            { "One button for all", "Одна кнопка для всех" },
            { "Separate left and right buttons", "Отдельные кнопки слева и справа" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "Кнопки модов слева" },
            { "Mod buttons — right", "Кнопки модов справа" },
            { "Launcher buttons", "Кнопки групп" },
            { "One button", "Одна кнопка" },
            { "Left / right", "Слева / справа" },
            { "Select buttons", "Выбрать кнопки" },
            { "Finish selection", "Завершить выбор" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "В режиме выбора нажимайте кнопки модов правой кнопкой мыши. Исключённые кнопки возвращаются в интерфейс игры, а в менеджере остаются их копии с непрозрачностью 40%. Чтобы завершить выбор, отключите параметр «Скрывать кнопки». Чтобы открыть настройки, щёлкните по этой кнопке группы правой кнопкой мыши. Перетаскивайте значки с зажатой левой кнопкой мыши, чтобы менять их порядок. Порядок сохраняется автоматически, а новые кнопки модов добавляются в конец." },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "Щелчок открывает или закрывает панель · Панель остаётся открытой · Правый щелчок открывает настройки · Перетаскивание перемещает кнопку" },
            { "Dock settings", "Настройки панели" },
            { "Close", "Закрыть" },
            { "Group buttons", "Группировать кнопки" },
            { "Lock launcher positions", "Закрепить кнопки групп" },
            { "Hide buttons (selection mode)", "Скрывать кнопки (режим выбора)" },
            { "Opening direction", "Направление открытия" },
            { "Rows", "Ряды" },
            { "Also include top left", "Также включать кнопки слева сверху" },
            { "Buttons in the dock", "Кнопки на панели" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "Включите «Скрывать кнопки», чтобы редактировать список или нажимать значки правой кнопкой мыши. Исключённые кнопки остаются в обычном интерфейсе игры. Отключите параметр, чтобы убрать из менеджера их копии с непрозрачностью 40%. Перетаскивайте значки с зажатой левой кнопкой мыши, чтобы менять их порядок. Порядок сохраняется автоматически, а новые кнопки модов добавляются в конец." },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "Поддерживаемые кнопки модов не найдены. Включите отображение кнопок в настройках соответствующих модов." },
            { "The shared mod UI hook is unavailable in this game version.", "Общая точка подключения интерфейса модов недоступна в этой версии игры." },
            { "Cannot safely position this button (transformed parent).", "Невозможно безопасно разместить кнопку из-за преобразования родительского элемента." },
            { "Reset dock", "Сбросить панель" },
            { "Collected buttons", "Кнопки в группе" },
            { "Previous page", "Предыдущая страница" },
            { "Next page", "Следующая страница" },
            { "Mod button", "Кнопка мода" },
            { "Version", "Версия" },
            { "Installed Mod Button Manager version.", "Установленная версия Mod Button Manager." },
            { "Group mod buttons", "Группировать кнопки модов" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "Объединяет выбранные кнопки модов из левого и правого верхних углов. При отключении кнопки возвращаются на прежние места." },
            { "Combined launcher opening direction", "Направление открытия общей группы" },
            { "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.", "Панель открывается снизу, сверху, справа или слева от кнопки группы. Если места не хватает, выбирается свободная область экрана." },
            { "Left launcher opening direction", "Направление открытия левой группы" },
            { "Opening direction of the left launcher in separate mode.", "Направление открытия панели от левой кнопки в раздельном режиме." },
            { "Right launcher opening direction", "Направление открытия правой группы" },
            { "Opening direction of the right launcher in separate mode.", "Направление открытия панели от правой кнопки в раздельном режиме." },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "Блокирует перетаскивание всех кнопок групп. Панели по-прежнему можно открывать и закрывать." },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "Включите, чтобы исключать кнопки в менеджере правым щелчком. Исключённые кнопки возвращаются в интерфейс игры, а их копии с непрозрачностью 40% остаются в менеджере. Отключите параметр, чтобы скрыть копии и завершить выбор." },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "Используйте одну кнопку для всех модов или отдельные кнопки слева и справа. Положение каждой кнопки сохраняется отдельно." },
            { "Arrange collected buttons in 1 to 10 rows. Large collections use pages.", "Размещает собранные кнопки в 1–10 рядах. Большие списки делятся на страницы." },
            { "Also collect top-left mod buttons", "Также группировать кнопки модов слева сверху" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "Необязательный параметр. В группу включаются только небольшие кнопки из общих точек подключения интерфейса модов. Крупные панели исключаются." },
            { "Restore the position, layout and button selection. Does not change other mods.", "Восстанавливает исходное положение, расположение и выбор кнопок. Настройки других модов сохраняются." },
            { "Show button count", "Показывать число кнопок" },
            { "Show the number of collected mod buttons on the launcher buttons.", "Показывает на каждой кнопке группы количество собранных в ней кнопок модов." },
            { "Above", "Вверх" },
        };
    }
}
