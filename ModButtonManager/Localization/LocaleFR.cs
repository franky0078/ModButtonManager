using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocaleFR : Locale
    {
        public LocaleFR(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "Général" },
            { "Layout", "Disposition" },
            { "Mod buttons", "Boutons de mods" },
            { "Reset", "Réinitialisation" },
            { "About", "À propos" },
            { "Below", "En dessous" },
            { "Right", "À droite" },
            { "Left", "À gauche" },
            { "One button for all", "Un bouton pour tous" },
            { "Separate left and right buttons", "Boutons séparés à gauche et à droite" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "Boutons de mods — gauche" },
            { "Mod buttons — right", "Boutons de mods — droite" },
            { "Launcher buttons", "Boutons de regroupement" },
            { "One button", "Un bouton" },
            { "Left / right", "Gauche / droite" },
            { "Select buttons", "Sélectionner les boutons" },
            { "Finish selection", "Terminer la sélection" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings.", "Mode de sélection : clic droit sur les boutons de mods. Les originaux exclus reviennent dans l’interface du jeu ; leurs aperçus dans le gestionnaire ont une opacité de 40 %. Désactivez Masquer les boutons dans les options pour terminer. Un clic droit sur ce bouton ouvre les réglages." },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "Cliquer pour ouvrir ou fermer · Reste ouvert · Clic droit pour les réglages · Faire glisser pour déplacer" },
            { "Dock settings", "Réglages du gestionnaire" },
            { "Close", "Fermer" },
            { "Group buttons", "Regrouper les boutons" },
            { "Lock launcher positions", "Verrouiller les positions des boutons de regroupement" },
            { "Hide buttons (selection mode)", "Masquer les boutons (mode de sélection)" },
            { "Opening direction", "Direction d’ouverture" },
            { "Rows", "Rangées" },
            { "Also include top left", "Inclure aussi les boutons en haut à gauche" },
            { "Buttons in the dock", "Boutons dans le gestionnaire" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager.", "Activez Masquer les boutons pour modifier cette liste ou faire un clic droit sur les icônes. Les boutons exclus restent dans l’interface normale du jeu. Désactivez cette option pour retirer leurs aperçus à 40 % d’opacité du gestionnaire." },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "Aucun bouton de mod compatible détecté. Les options d’affichage de leurs boutons doivent être activées dans les mods concernés." },
            { "The shared mod UI hook is unavailable in this game version.", "Le point d’intégration commun des mods est indisponible dans cette version du jeu." },
            { "Cannot safely position this button (transformed parent).", "Impossible de positionner ce bouton de manière sûre (élément parent transformé)." },
            { "Reset dock", "Réinitialiser le gestionnaire" },
            { "Collected buttons", "Boutons regroupés" },
            { "Previous page", "Page précédente" },
            { "Next page", "Page suivante" },
            { "Mod button", "Bouton de mod" },
            { "Version", "Version" },
            { "Installed Mod Button Manager version.", "Version installée de Mod Button Manager." },
            { "Group mod buttons", "Regrouper les boutons de mods" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "Regroupe les boutons de mods sélectionnés en haut à gauche et à droite. Désactivez cette option pour rétablir leurs positions initiales." },
            { "Combined launcher opening direction", "Direction d’ouverture du bouton commun" },
            { "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.", "Ouvre le menu en dessous, au-dessus, à droite ou à gauche du bouton de lancement. Utilise l’espace disponible à l’écran si nécessaire." },
            { "Left launcher opening direction", "Direction d’ouverture à gauche" },
            { "Opening direction of the left launcher in separate mode.", "Direction d’ouverture du bouton de regroupement gauche en mode séparé." },
            { "Right launcher opening direction", "Direction d’ouverture à droite" },
            { "Opening direction of the right launcher in separate mode.", "Direction d’ouverture du bouton de regroupement droit en mode séparé." },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "Empêche le déplacement de tous les boutons de regroupement. Ils peuvent toujours être ouverts et fermés." },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "Activez cette option pour sélectionner les boutons par clic droit dans le gestionnaire. Les originaux exclus reviennent dans l’interface du jeu ; leurs aperçus à 40 % d’opacité restent dans le gestionnaire. Désactivez cette option pour retirer les aperçus et terminer." },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "Utilise un bouton commun pour tous les boutons de mods ou des boutons séparés à gauche et à droite. Chaque position est enregistrée séparément." },
            { "Arrange collected buttons in 1 to 10 rows. Large collections use pages.", "Dispose les boutons regroupés sur 1 à 10 rangées. Les grandes collections sont réparties sur plusieurs pages." },
            { "Also collect top-left mod buttons", "Regrouper aussi les boutons de mods en haut à gauche" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "Facultatif. Seuls les petits boutons des points d’intégration communs sont regroupés ; les grandes fenêtres sont exclues." },
            { "Restore the position, layout and button selection. Does not change other mods.", "Rétablit les positions, la disposition et la sélection des boutons. Ne modifie pas les autres mods." },
            { "Show button count", "Afficher le nombre de boutons" },
            { "Show the number of collected mod buttons on the launcher buttons.", "Affiche le nombre de boutons de mods regroupés sur les boutons de lancement." },
            { "Above", "Au-dessus" },
        };
    }
}
