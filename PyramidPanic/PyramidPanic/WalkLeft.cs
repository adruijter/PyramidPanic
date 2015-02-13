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
    public class WalkLeft : AnimatedSprite, IAnimatedSprite
    {
        // Fields
        private Scorpion scorpion;

        // Properties
        public Rectangle DestinationRectangle
        {
            set { this.destinationRectangle = value; }
            get { return this.destinationRectangle; }
        }

        // Constructor
        public WalkLeft(Scorpion scorpion) : base(scorpion)
        {
            this.scorpion = scorpion;
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X,
                                                      (int)this.scorpion.Position.Y,
                                                      this.scorpion.Texture.Width / 4,
                                                      this.scorpion.Texture.Height);
            this.effect = SpriteEffects.FlipHorizontally;
            //this.rotation = (float)Math.PI;
        }

        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            this.scorpion.Position -= new Vector2(1f, 0f);
            base.Update(gameTime);
        }


        // Draw
        public void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
