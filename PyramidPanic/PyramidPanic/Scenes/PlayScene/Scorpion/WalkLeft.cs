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
            this.rotation = (float)Math.PI;
        }

        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
        }

        // Update
        public override void Update(GameTime gameTime)
        {
            if (this.scorpion.Position.X > this.scorpion.LeftBorder) // check of de x-pos groter is dan 32f)
            {
                this.scorpion.Position -= this.scorpion.Speed;
            }
            else
            {
                this.scorpion.State = this.scorpion.WalkRight;
            }
            base.Update(gameTime);
        }


        // Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
