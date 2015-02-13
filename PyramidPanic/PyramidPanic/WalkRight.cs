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
    public class WalkRight : AnimatedSprite, IState
    {
        // Fields
        private Scorpion scorpion;

        // Properties


        // Constructor
        public WalkRight(Scorpion scorpion) : base(scorpion)
        {
            this.scorpion = scorpion;
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X,
                                                      (int)this.scorpion.Position.Y,
                                                      this.scorpion.Texture.Width / 4,
                                                      this.scorpion.Texture.Height);

        }

        // Update
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        // Draw
        public void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
