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

        public static bool CollisionDetectExplorerWallsDown()
        {
            int stepX32 = (int)((level.Explorer.Position.X - 16) / 32);
            int stepY32 = (int)((level.Explorer.Position.Y - 16) / 32);

            if (level.Block[stepX32, stepY32 + 1].Passable == false)
            {
                if (level.Explorer.CollisionRectangle.
                        Intersects(level.Block[stepX32, stepY32 + 1].CollisionRectangle))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CollisionDetectExplorerWallsLeft()
        {
            int stepX32 = (int)((level.Explorer.Position.X - 16) / 32);
            int stepY32 = (int)((level.Explorer.Position.Y - 16) / 32);

            if (level.Block[stepX32, stepY32].Passable == false)
            {
                if (level.Explorer.CollisionRectangle.
                        Intersects(level.Block[stepX32, stepY32].CollisionRectangle))
                {
                    return true;
                }
            }
            return false;
        }


        public static bool CollisionDetectExplorerWallsUp()
        {
            int stepX32 = (int)((level.Explorer.Position.X - 16) / 32);
            int stepY32 = (int)((level.Explorer.Position.Y - 16) / 32);

            if (level.Block[stepX32, stepY32].Passable == false)
            {
                if (level.Explorer.CollisionRectangle.
                        Intersects(level.Block[stepX32, stepY32].CollisionRectangle))
                {
                    return true;
                }
            }
            return false;
        }

        public static void CollisionDetectTreasures()
        {
            foreach (Image image in level.Treasures)
            {
                if (level.Explorer.CollisionRectangle.Intersects(image.Rectangle))
                {
                    level.Treasures.Remove(image);
                    switch (image.Character)
                    {
                        case 'c':

                            break;
                        case 'a':
                            break;
                        case 'p':
                            Scores.Lives++;
                            break;
                        case 's':
                            break;
                    }
                    break;
                }                
            }
        }

        public static void CollisionDetectScorpions()
        {
            foreach (Scorpion scorpion in level.Scorpions)
            {
                if (level.Explorer.CollisionRectangle.Intersects(scorpion.CollisionRectangle))
                {
                    if (level.LevelState.Equals(level.LevelPlay))
                    {
                        level.LevelState = level.LevelCollisionPause;
                        Scores.Lives--;
                    }
                    else
                    {
                        level.Scorpions.Remove(scorpion);
                        level.Explorer.State = level.Explorer.Idle;
                        level.Explorer.Idle.Rotation = 0f;
                        level.Explorer.Idle.Effect = SpriteEffects.None;
                        level.Explorer.Position = new Vector2(8 * 32f - 16f, 8 * 32f - 16f);
                    }
                    break;
                }
            }
        }
    }
}
