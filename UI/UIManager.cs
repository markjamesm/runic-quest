using Microsoft.Xna.Framework;
using SadConsole;
using GoRogue;
using GoRogue.GameFramework;
using GoRogue.MapGeneration;
using GoRogue.MapViews;
using XnaRect = Microsoft.Xna.Framework.Rectangle;

namespace RunicQuest.UI
{
    // Creates/Holds/Destroys all consoles used in the game
    // and makes consoles easily addressable from a central place.
    public class UIManager : ContainerConsole
    {

        // Set the map and viewport dimensions.
        public const int ViewPortWidth = 80;
        public const int ViewPortHeight = 25;

        private const int MapWidth = 500;
        private const int MapHeight = 500;

        // Create our windows
        internal MapScreen MapScreen { get; private set; }
        public MessageLogWindow MessageLog;

        private SplashScreen SplashScreen;

        public UIManager()
        {
            // must be set to true
            // or will not call each child's Draw method
            IsVisible = true;
            IsFocused = true;

            // The UIManager becomes the only
            // screen that SadConsole processes
            Parent = SadConsole.Global.CurrentScreen;
        }

        // Creates all child consoles to be managed
        // make sure they are added as children
        // so they are updated and drawn
        public void CreateConsoles()
        {

            // Display the Splashscreen
            SplashScreen = new SplashScreen();
            Children.Add(SplashScreen);
            SplashScreen.IsVisible = true;

            // Generate the map and add it as a Child of the UI manager
            MapScreen = new MapScreen(MapWidth, MapHeight, ViewPortWidth, ViewPortHeight);
            Children.Add(MapScreen);

            // Create the message log window and set its position.
            MessageLog = new MessageLogWindow(ViewPortWidth, ViewPortHeight / 4, "Message Log");
            Children.Add(MessageLog);
            MessageLog.Show();
            MessageLog.Position = new Point(0, 20);

            // Print a test method
            MessageLog.Add("Welcome to Runic Quest Alpha!");
        }
    }
}