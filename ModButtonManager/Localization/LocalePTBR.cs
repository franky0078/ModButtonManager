using System.Collections.Generic;
using ModButtonManager.Settings;

namespace ModButtonManager.Localization
{
    public sealed class LocalePTBR : Locale
    {
        public LocalePTBR(Setting setting) : base(setting, Texts) { }

        private static readonly Dictionary<string, string> Texts = new Dictionary<string, string>
        {
            { "General", "Geral" },
            { "Layout", "Layout" },
            { "Mod buttons", "Botões de mods" },
            { "Reset", "Redefinição" },
            { "About", "Sobre" },
            { "Below", "Abaixo" },
            { "Right", "À direita" },
            { "Left", "À esquerda" },
            { "One button for all", "Um botão para todos" },
            { "Separate left and right buttons", "Botões separados à esquerda e à direita" },
            { "Mod Button Manager", "Mod Button Manager" },
            { "Mod buttons — left", "Botões de mods à esquerda" },
            { "Mod buttons — right", "Botões de mods à direita" },
            { "Launcher buttons", "Botões agrupadores" },
            { "One button", "Um botão" },
            { "Left / right", "Esquerda / direita" },
            { "Select buttons", "Selecionar botões" },
            { "Finish selection", "Concluir seleção" },
            { "Selection mode: right-click mod buttons. Excluded originals return to the game UI; manager previews have 40% opacity. Turn off Hide buttons in options to finish. Right-click this launcher for settings. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "No modo de seleção, clique com o botão direito nos botões de mods. Os botões excluídos voltam à interface do jogo, e suas prévias no gerenciador ficam com 40% de opacidade. Para concluir, desative a opção «Ocultar botões». Clique com o botão direito neste botão agrupador para abrir as configurações. Mantenha o botão esquerdo do mouse pressionado e arraste os ícones para reordená-los. A ordem é salva automaticamente, e os novos botões são adicionados ao final." },
            { "Click to open or close · Stays open · Right-click for settings · Drag to move", "Clique para abrir ou fechar · Permanece aberto · Clique com o botão direito para configurar · Arraste para mover" },
            { "Dock settings", "Configurações do painel" },
            { "Close", "Fechar" },
            { "Group buttons", "Agrupar botões" },
            { "Lock launcher positions", "Bloquear posições dos botões agrupadores" },
            { "Hide buttons (selection mode)", "Ocultar botões (modo de seleção)" },
            { "Opening direction", "Direção de abertura" },
            { "Rows", "Linhas" },
            { "Also include top left", "Incluir também o canto superior esquerdo" },
            { "Buttons in the dock", "Botões no painel" },
            { "Enable Hide buttons to edit this list or right-click the icons. Excluded buttons remain in the normal game UI. Disable to remove their 40% opacity previews from the manager. Hold the left mouse button and drag icons to reorder them. The order is saved automatically; new mod buttons are added at the end.", "Ative «Ocultar botões» para editar esta lista ou clicar com o botão direito nos ícones. Os botões excluídos permanecem na interface normal do jogo. Desative a opção para remover do gerenciador as prévias com 40% de opacidade. Mantenha o botão esquerdo do mouse pressionado e arraste os ícones para reordená-los. A ordem é salva automaticamente, e os novos botões são adicionados ao final." },
            { "No supported mod buttons found. Their own launcher options must be enabled.", "Nenhum botão de mod compatível foi encontrado. Ative a exibição dos botões nas opções de cada mod." },
            { "The shared mod UI hook is unavailable in this game version.", "O ponto de integração compartilhado da interface dos mods não está disponível nesta versão do jogo." },
            { "Cannot safely position this button (transformed parent).", "Não é possível posicionar este botão com segurança porque o elemento pai tem uma transformação aplicada." },
            { "Reset dock", "Redefinir painel" },
            { "Collected buttons", "Botões agrupados" },
            { "Previous page", "Página anterior" },
            { "Next page", "Próxima página" },
            { "Mod button", "Botão de mod" },
            { "Version", "Versão" },
            { "Installed Mod Button Manager version.", "Versão instalada do Mod Button Manager." },
            { "Group mod buttons", "Agrupar botões de mods" },
            { "Collect selected top-left and top-right mod buttons. Disable to restore their original positions.", "Agrupa os botões de mods selecionados nos cantos superiores esquerdo e direito. Desative para restaurar as posições originais." },
            { "Combined launcher opening direction", "Direção de abertura do botão agrupador único" },
            { "Open below, above, to the right or to the left of the dock button. Falls back to available screen space when needed.", "Abre o painel abaixo, acima, à direita ou à esquerda do botão agrupador. Se necessário, usa o espaço disponível na tela." },
            { "Left launcher opening direction", "Direção de abertura do botão agrupador esquerdo" },
            { "Opening direction of the left launcher in separate mode.", "Direção em que o painel abre a partir do botão esquerdo no modo separado." },
            { "Right launcher opening direction", "Direção de abertura do botão agrupador direito" },
            { "Opening direction of the right launcher in separate mode.", "Direção em que o painel abre a partir do botão direito no modo separado." },
            { "Prevent dragging all launcher buttons. Opening and closing remains available.", "Impede o deslocamento dos botões agrupadores por arraste. Ainda é possível abrir e fechar o painel." },
            { "Enable to right-click buttons in the manager. Excluded originals return to the game UI; 40% opacity previews remain in the manager. Disable to hide previews and finish selection.", "Ative para excluir botões no gerenciador com o botão direito do mouse. Os botões excluídos voltam à interface do jogo, e suas prévias ficam no gerenciador com 40% de opacidade. Desative para ocultar as prévias e concluir a seleção." },
            { "Use one button for all mod launchers, or separate buttons for left and right. Each position is saved separately.", "Use um botão para todos os botões de mods ou separe-os entre esquerda e direita. Cada posição é salva separadamente." },
            { "Arrange collected buttons in 1 to 10 rows. Large collections use pages.", "Organiza os botões agrupados em 1 a 10 linhas. Listas maiores são divididas em páginas." },
            { "Also collect top-left mod buttons", "Agrupar também botões de mods do canto superior esquerdo" },
            { "Optional. Only small launcher buttons in the shared mod UI hooks are collected; large panels are excluded.", "Opcional. Agrupa apenas botões pequenos nos pontos de integração compartilhados da interface de mods. Painéis grandes são excluídos." },
            { "Restore the position, layout and button selection. Does not change other mods.", "Restaura a posição, o layout e a seleção de botões. As configurações dos outros mods são preservadas." },
            { "Show button count", "Mostrar quantidade de botões" },
            { "Show the number of collected mod buttons on the launcher buttons.", "Mostra nos botões agrupadores a quantidade de botões de mods reunidos." },
            { "Above", "Acima" },
        };
    }
}
