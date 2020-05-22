using Microsoft.Xna.Framework;
using RunicQuest;
using SadConsole;
namespace SadConsoleRLTutorial
{
    // Creates/Holds/Destroys all consoles used in the game
    // and makes consoles easily addressable from a central place.
    public class UIManager : ContainerConsole
    {

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
       //     MapScreen = new MapScreen(MapWidth, MapHeight, ViewPortWidth, ViewPortHeight);
        }
    }
}