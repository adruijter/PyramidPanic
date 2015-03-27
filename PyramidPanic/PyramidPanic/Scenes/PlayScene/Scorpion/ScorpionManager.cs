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
    public class ScorpionManager
    {
        // Fields
        private Level level;

        // Properties


        // Constructor
        public ScorpionManager(Level level)
        {
            this.level = level;
            this.CollisionDetectScorpionRight();
            this.CollisionDetectScorpionLeft();
        }



        // Methods
        private void CollisionDetectScorpionRight()
        {
            foreach (Scorpion scorpion in this.level.Scorpions)
            {
                for (int i = (int)(scorpion.Position.X / 32f); i < 20; i++)
                {
                    if ( this.level.Block[i, (int)(scorpion.Position.Y/32f)].Passable == false)
                    {
                        scorpion.RightBorder = i * 32f - 16f ;
                        break;
                    }
                }
            }
        }


        private void CollisionDetectScorpionLeft()
        {
            foreach (Scorpion scorpion in this.level.Scorpions)
            {
                for (int i = (int)(scorpion.Position.X / 32f); i >= 0; i--)
                {
                    if (this.level.Block[i, (int)(scorpion.Position.Y / 32f)].Passable == false)
                    {
                        scorpion.LeftBorder = (i + 1) * 32f + 16f;
                        break;
                    }
                }
            }
        }
    }
}
