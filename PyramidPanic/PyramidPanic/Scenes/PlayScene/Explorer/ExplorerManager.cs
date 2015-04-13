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
        private static bool oldValueOpenDoors;

        // Properties
        public static Level Level
        {
            set { level = value; }
        }


        public static bool CollisionDetectExplorerWallsRight()
        {
            int stepX32 = (int)((level.Explorer.Position.X - 16) / 32);

            if (stepX32 > 18)
            {
                stepX32 = 18;
            }

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

            if (stepX32 < 0)
            {
                stepX32 = 0;
            }

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

            if (stepY32 < 0)
            {
                stepY32 = 0;
            }

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
                            Scores.Points += 100;
                            break;
                        case 'a':
                            Scores.Points += 10;
                            break;
                        case 'p':
                            Scores.Lives++;
                            break;
                        case 's':
                            Scores.Points += 50;
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

        public static void WalkOutOfLevel()
        {
            if (level.Explorer.Position.Y >= 448 ||
                level.Explorer.Position.X >= 640 ||
                level.Explorer.Position.Y <= 0   ||
                level.Explorer.Position.X <= 0)
            {
                level.LevelState = level.LevelNextLevel;
            }
        }

        //private static bool oldValueOpenDoors

        public static void OpenDoors()
        {
            
            if (Scores.OpenDoors && !oldValueOpenDoors)                 //1
            {
                for (int i=0; i < level.Block.GetLength(0); i++)
                {
                    for (int j=0; j < level.Block.GetLength(1) ; j++)
                    {
                        if (level.Block[i, j].Character == '3')
                        {
                            level.Block[i, j].Passable = true;
                        }
                    }
                }
                level.LevelState = level.LevelDoorsOpen;                //2
            }
            oldValueOpenDoors = Scores.OpenDoors;                       //4
        }
    }
}
