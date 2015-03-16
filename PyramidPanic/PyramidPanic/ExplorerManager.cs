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
            int stepX32 = (int)((level.Explorer.Position.X - 16) / 32);
            int stepY32 = (int)((level.Explorer.Position.Y - 16) / 32);
            
            if (level.Block[stepX32 + 1, stepY32].Passable == false)
                {
                    if (level.Explorer.CollisionRectangle.
                            Intersects(level.Block[stepX32 + 1, stepY32].CollisionRectangle))
                    {
                        return true;
                    }
                }            
            return false;
        }
    }
}
