using GoRogue.GameFramework;
using SadConsole;

namespace RunicQuest
{
    internal class GameLoop
    {

        public static UIManager UIManager;

        private static void Main()
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create(UIManager.ViewPortWidth, UIManager.ViewPortHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Start the game.
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        private static void Init()
        {
            // Create our UI Manager and then spawn our consoles.
            UIManager = new UIManager();

            // From an unreleased SadConsole build. Will uncomment when its release.
            // SadConsole.Themes.Library.Default.Colors = SadConsole.Themes.Colors.CreateAnsi();
            UIManager.CreateConsoles();

        }
    }
}
