using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class ExplorerManager
    {
        // Fields
        private static Level level;

        // Properties
        public static Level Level
        {
            set { level = value; }
        }


        public static bool CollisionDetectExplorerWallsRight()
        {
                if (level.Block[(int)((level.Explorer.Position.X - 16) /32) + 1,
                                (int)((level.Explorer.Position.Y - 16)/32)].Passable == false)
                {
                    if (level.Explorer.State.DestinationRectangle.
                            Intersects(level.Block[(int)((level.Explorer.Position.X - 16)/32),
                                                   (int)((level.Explorer.Position.Y - 16)/ 32)]
                                                            .CollisionRectangle))
                    {
                        return false;
                    }
                }            
            return true;
        }
    }
}
