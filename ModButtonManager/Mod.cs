using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using ModButtonManager.Settings;
using ModButtonManager.Localization;
using ModButtonManager.Systems;

namespace ModButtonManager
{
    public sealed class Mod : IMod
    {
        public static readonly ILog Log = LogManager.GetLogger(nameof(ModButtonManager))
            .SetShowsErrorsInUI(false);
        public static string Version => typeof(Mod).Assembly.GetName().Version.ToString(3);
        public static Setting Settings { get; private set; }

        public void OnLoad(UpdateSystem updateSystem)
        {
            Settings = new Setting(this);
            AssetDatabase.global.LoadSettings(nameof(ModButtonManager), Settings, new Setting(this));
            Settings.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Settings));
            GameManager.instance.localizationManager.AddSource("de-DE", new LocaleDE(Settings));
            GameManager.instance.localizationManager.AddSource("fr-FR", new LocaleFR(Settings));
            GameManager.instance.localizationManager.AddSource("it-IT", new LocaleIT(Settings));
            GameManager.instance.localizationManager.AddSource("es-ES", new LocaleES(Settings));
            updateSystem.UpdateAt<DockUISystem>(SystemUpdatePhase.UIUpdate);
            Log.Info($"Mod Button Manager {Version} loaded (experimental).");
        }

        public void OnDispose()
        {
            Settings?.UnregisterInOptionsUI();
            Settings = null;
        }
    }
}
