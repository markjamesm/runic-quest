namespace RunicQuest
{
    internal class Program
    {

        private const int StartingWidth = 80;
        private const int StartingHeight = 25;

        public static MapScreen MapScreen { get; set; }

        private static void Main()
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create(StartingWidth, StartingHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Start the game.
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        private static void Init()
        {
            // Here we pass the viewport and map size as the same, but the map could be larger and the camera would center on the player.
            MapScreen = new MapScreen(StartingWidth, StartingHeight, StartingWidth, StartingHeight);
            SadConsole.Global.CurrentScreen = MapScreen;
        }
    }
}
