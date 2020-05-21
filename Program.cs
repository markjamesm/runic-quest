namespace RunicQuest
{
    internal class Program
    {
        // Set the map and viewport dimensions.
        private const int ViewPortWidth = 80;
        private const int ViewPortHeight = 25;

        private const int MapWidth = 500;
        private const int MapHeight = 500;

        public static MapScreen MapScreen { get; set; }

        private static void Main()
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create(ViewPortWidth, ViewPortHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Start the game.
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        private static void Init()
        {
            // Here we pass the viewport and map size as the same, but the map could be larger and the camera would center on the player.
            MapScreen = new MapScreen(MapWidth, MapHeight, ViewPortWidth, ViewPortHeight);
            SadConsole.Global.CurrentScreen = MapScreen;
        }
    }
}
