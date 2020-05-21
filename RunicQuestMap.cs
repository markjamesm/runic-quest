using System;
using GoRogue;
using Microsoft.Xna.Framework;
using SadConsole;

namespace RunicQuest
{
    internal enum MapLayer
    {
        TERRAIN,
        ITEMS,
        MONSTERS,
        PLAYER
    }

    internal class RunicQuestMap : BasicMap
    {
        // Handles the changing of tile/entity visiblity as appropriate based on Map.FOV.
        public FOVVisibilityHandler FovVisibilityHandler { get; }

        // Since we'll want to access the player as our Player type, create a property to do the cast for us.  The cast must succeed thanks to the ControlledGameObjectTypeCheck
        // implemented in the constructor.
        public new Player ControlledGameObject
        {
            get => (Player)base.ControlledGameObject;
            set => base.ControlledGameObject = value;
        }

        public RunicQuestMap(int width, int height)
            // Allow multiple items on the same location only on the items layer.  This example uses 8-way movement, so Chebyshev distance is selected.
            : base(width, height, Enum.GetNames(typeof(MapLayer)).Length - 1, Distance.CHEBYSHEV, entityLayersSupportingMultipleItems: LayerMasker.DEFAULT.Mask((int)MapLayer.ITEMS))
        {
            ControlledGameObjectChanged += ControlledGameObjectTypeCheck<Player>; // Make sure we don't accidentally assign anything that isn't a Player type to ControlledGameObject
            FovVisibilityHandler = new DefaultFOVVisibilityHandler(this, ColorAnsi.BlackBright);
        }
    }
}
