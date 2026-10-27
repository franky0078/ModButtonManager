using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocaleIT : Locale
    {
        public LocaleIT(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "Generale" },
            { "Layout", "Disposizione" },
            { "Mod buttons", "Pulsanti delle mod" },
            { "Reset", "Ripristino" },
            { "About", "Informazioni" },
            { "Below", "Sotto" },
            { "Right", "A destra" },
            { "Left", "A sinistra" },
            { "One button for all", "Un pulsante per tutti" },
            { "Separate left and right buttons", "Pulsanti separati a sinistra e a destra" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "Pulsanti delle mod — sinistra" },
            { "Mod buttons — right", "Pulsanti delle mod — destra" },
            { "Launcher buttons", "Pulsanti di raccolta" },
            { "One button", "Un pulsante" },
            { "Left / right", "Sinistra / destra" },
            { "Select buttons", "Seleziona pulsanti" },
            { "Finish selection", "Termina selezione" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "Modalità selezione: clic destro sui pulsanti delle mod. Gli originali esclusi tornano nell’interfaccia del gioco; le anteprime nel gestore hanno un’opacità del 40%. Disattiva Nascondi pulsanti nelle opzioni per terminare. Un clic destro su questo pulsante apre le impostazioni. Tieni premuto il pulsante sinistro del mouse e trascina le icone per riordinarle. L’ordine viene salvato automaticamente; i nuovi pulsanti vengono aggiunti alla fine." },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "Clic per aprire o chiudere · Rimane aperto · Clic destro per le impostazioni · Trascina per spostare" },
            { "Dock settings", "Impostazioni del gestore" },
            { "Close", "Chiudi" },
            { "Group buttons", "Raggruppa pulsanti" },
            { "Lock launcher positions", "Blocca le posizioni dei pulsanti di raccolta" },
            { "Hide buttons (selection mode)", "Nascondi pulsanti (modalità selezione)" },
            { "Opening direction", "Direzione di apertura" },
            { "Rows", "Righe" },
            { "Also include top left", "Includi anche i pulsanti in alto a sinistra" },
            { "Buttons in the dock", "Pulsanti nel gestore" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "Attiva Nascondi pulsanti per modificare questo elenco o fare clic destro sulle icone. I pulsanti esclusi rimangono nell’interfaccia normale del gioco. Disattiva l’opzione per rimuovere dal gestore le anteprime con opacità del 40%. Tieni premuto il pulsante sinistro del mouse e trascina le icone per riordinarle. L’ordine viene salvato automaticamente; i nuovi pulsanti vengono aggiunti alla fine." },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "Nessun pulsante di mod compatibile trovato. L’opzione per mostrare il pulsante deve essere attiva nella relativa mod." },
            { "The shared mod UI hook is unavailable in this game version.", "Il punto di integrazione comune delle mod non è disponibile in questa versione del gioco." },
            { "Cannot safely position this button (transformed parent).", "Impossibile posizionare questo pulsante in modo sicuro (elemento padre trasformato)." },
            { "Reset dock", "Ripristina gestore" },
            { "Collected buttons", "Pulsanti raggruppati" },
            { "Previous page", "Pagina precedente" },
            { "Next page", "Pagina successiva" },
            { "Mod button", "Pulsante di mod" },
            { "Version", "Versione" },
            { "Installed Mod Button Manager version.", "Versione installata di Mod Button Manager." },
            { "Group mod buttons", "Raggruppa pulsanti delle mod" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "Raggruppa i pulsanti selezionati delle mod in alto a sinistra e a destra. Disattiva per ripristinare le posizioni originali." },
            { "Combined launcher opening direction", "Direzione di apertura del pulsante comune" },
            { "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.", "Apre il menu sotto, sopra, a destra o a sinistra del pulsante di avvio. Se necessario, usa lo spazio disponibile sullo schermo." },
            { "Left launcher opening direction", "Direzione di apertura a sinistra" },
            { "Opening direction of the left launcher in separate mode.", "Direzione di apertura del pulsante di raccolta sinistro in modalità separata." },
            { "Right launcher opening direction", "Direzione di apertura a destra" },
            { "Opening direction of the right launcher in separate mode.", "Direzione di apertura del pulsante di raccolta destro in modalità separata." },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "Impedisce di trascinare tutti i pulsanti di raccolta. È comunque possibile aprirli e chiuderli." },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "Attiva per selezionare i pulsanti nel gestore con il clic destro. Gli originali esclusi tornano nell’interfaccia del gioco; nel gestore rimangono anteprime con opacità del 40%. Disattiva per rimuovere le anteprime e terminare." },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "Usa un pulsante comune per tutte le mod o pulsanti separati a sinistra e a destra. Ogni posizione viene salvata separatamente." },
            { "Arrange collected buttons in 1 to 10 rows. Large collections use pages.", "Dispone i pulsanti raggruppati su un numero di righe da 1 a 10. Le raccolte grandi usano più pagine." },
            { "Also collect top-left mod buttons", "Raggruppa anche i pulsanti delle mod in alto a sinistra" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "Facoltativo. Raggruppa solo i piccoli pulsanti nei punti di integrazione comuni delle mod; le finestre grandi sono escluse." },
            { "Restore the position, layout and button selection. Does not change other mods.", "Ripristina posizioni, disposizione e selezione dei pulsanti. Non modifica le altre mod." },
            { "Show button count", "Mostra il numero di pulsanti" },
            { "Show the number of collected mod buttons on the launcher buttons.", "Mostra il numero di pulsanti delle mod raggruppati sui pulsanti di avvio." },
            { "Above", "Sopra" },
        };
    }
}
