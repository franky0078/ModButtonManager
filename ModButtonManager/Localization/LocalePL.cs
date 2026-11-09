using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocalePL : Locale
    {
        public LocalePL(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "Ogólne" },
            { "Layout", "Układ" },
            { "Mod buttons", "Przyciski modów" },
            { "Reset", "Resetowanie" },
            { "About", "Informacje" },
            { "Below", "W dół" },
            { "Right", "W prawo" },
            { "Left", "W lewo" },
            { "One button for all", "Jeden przycisk dla wszystkich" },
            { "Separate left and right buttons", "Osobne przyciski po lewej i prawej" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "Przyciski modów po lewej" },
            { "Mod buttons — right", "Przyciski modów po prawej" },
            { "Launcher buttons", "Przyciski zbiorcze" },
            { "One button", "Jeden przycisk" },
            { "Left / right", "Lewy / prawy" },
            { "Select buttons", "Wybierz przyciski" },
            { "Finish selection", "Zakończ wybór" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "Tryb wyboru: kliknij przyciski modów prawym przyciskiem myszy. Wykluczone przyciski wrócą do interfejsu gry, a ich podglądy w menedżerze mają krycie 40%. Aby zakończyć, wyłącz opcję „Ukryj przyciski”. Kliknij ten przycisk zbiorczy prawym przyciskiem myszy, aby otworzyć ustawienia. Przytrzymaj lewy przycisk myszy i przeciągnij ikony, aby zmienić ich kolejność. Kolejność zapisuje się automatycznie, a nowe przyciski modów trafiają na koniec." },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "Kliknij, aby otworzyć lub zamknąć · Pozostaje otwarty · Kliknij prawym, aby otworzyć ustawienia · Przeciągnij, aby przesunąć" },
            { "Dock settings", "Ustawienia doku" },
            { "Close", "Zamknij" },
            { "Group buttons", "Grupuj przyciski" },
            { "Lock launcher positions", "Zablokuj położenie przycisków zbiorczych" },
            { "Hide buttons (selection mode)", "Ukryj przyciski (tryb wyboru)" },
            { "Opening direction", "Kierunek otwierania" },
            { "Rows", "Wiersze" },
            { "Also include top left", "Uwzględnij też lewy górny róg" },
            { "Buttons in the dock", "Przyciski w doku" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "Włącz opcję „Ukryj przyciski”, aby edytować tę listę lub klikać ikony prawym przyciskiem myszy. Wykluczone przyciski pozostają w zwykłym interfejsie gry. Wyłącz opcję, aby usunąć z menedżera ich podglądy o kryciu 40%. Przytrzymaj lewy przycisk myszy i przeciągnij ikony, aby zmienić ich kolejność. Kolejność zapisuje się automatycznie, a nowe przyciski modów trafiają na koniec." },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "Nie znaleziono obsługiwanych przycisków modów. Włącz wyświetlanie przycisków w opcjach poszczególnych modów." },
            { "The shared mod UI hook is unavailable in this game version.", "Wspólny punkt integracji interfejsu modów jest niedostępny w tej wersji gry." },
            { "Cannot safely position this button (transformed parent).", "Nie można bezpiecznie umieścić tego przycisku, ponieważ element nadrzędny został przekształcony." },
            { "Reset dock", "Zresetuj dok" },
            { "Collected buttons", "Zebrane przyciski" },
            { "Previous page", "Poprzednia strona" },
            { "Next page", "Następna strona" },
            { "Mod button", "Przycisk moda" },
            { "Version", "Wersja" },
            { "Installed Mod Button Manager version.", "Zainstalowana wersja Mod Button Manager." },
            { "Group mod buttons", "Grupuj przyciski modów" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "Grupuje wybrane przyciski modów z lewego i prawego górnego rogu. Wyłączenie przywraca ich pierwotne położenie." },
            { "Combined launcher opening direction", "Kierunek otwierania wspólnego przycisku" },
            { "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.", "Dok otwiera się poniżej, powyżej, z prawej lub lewej strony przycisku. W razie potrzeby otworzy się tam, gdzie jest wolne miejsce." },
            { "Left launcher opening direction", "Kierunek otwierania lewego przycisku" },
            { "Opening direction of the left launcher in separate mode.", "Kierunek otwierania lewego przycisku zbiorczego w trybie osobnych przycisków." },
            { "Right launcher opening direction", "Kierunek otwierania prawego przycisku" },
            { "Opening direction of the right launcher in separate mode.", "Kierunek otwierania prawego przycisku zbiorczego w trybie osobnych przycisków." },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "Blokuje przeciąganie wszystkich przycisków zbiorczych. Nadal można je otwierać i zamykać." },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "Włącz, aby wykluczać przyciski w menedżerze prawym przyciskiem myszy. Wykluczone przyciski wracają do interfejsu gry, a ich podglądy o kryciu 40% pozostają w menedżerze. Wyłącz, aby ukryć podglądy i zakończyć wybór." },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "Użyj jednego wspólnego przycisku dla wszystkich modów albo osobnych przycisków dla lewej i prawej strony. Położenia są zapisywane oddzielnie." },
            { "Arrange collected buttons in 1 to 10 rows. Large collections use pages.", "Rozmieszcza zebrane przyciski w od 1 do 10 wierszy. Większe zestawy są dzielone na strony." },
            { "Also collect top-left mod buttons", "Grupuj także przyciski modów z lewego górnego rogu" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "Opcjonalnie. Grupuje tylko małe przyciski dostępne przez wspólne punkty integracji interfejsu modów. Duże panele są pomijane." },
            { "Restore the position, layout and button selection. Does not change other mods.", "Przywraca domyślne położenie, układ i wybór przycisków. Nie zmienia ustawień innych modów." },
            { "Show button count", "Pokaż liczbę przycisków" },
            { "Show the number of collected mod buttons on the launcher buttons.", "Wyświetla liczbę zebranych przycisków modów na przyciskach zbiorczych." },
            { "Above", "W górę" },
        };
    }
}
