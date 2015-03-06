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
    public class ExplorerWalkLeft : AnimatedSprite, IAnimatedSprite
    {

        // Fields
        private Explorer explorer;
        private Vector2 speed;

        // Properties
        public Rectangle DestinationRectangle
        {
            set { this.destinationRectangle = value; }
            get { return this.destinationRectangle; }
        }

        // Constructor
        public ExplorerWalkLeft(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                      (int)this.explorer.Position.Y,
                                                      this.explorer.Texture.Width / 4,
                                                      this.explorer.Texture.Height);
            this.rotation = (float)Math.PI;
            this.speed = new Vector2(this.explorer.Speed, 0f);

        }

        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        // Update
        public override void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Rotation = (float)Math.PI;
            }
            this.explorer.Position -= this.speed;
            base.Update(gameTime);
        }


        // Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
