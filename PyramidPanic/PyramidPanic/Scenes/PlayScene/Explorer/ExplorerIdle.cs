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
    public class ExplorerIdle : AnimatedSprite, IAnimatedSprite
    {

        // Fields
        private Explorer explorer;

        // Properties
        public Rectangle DestinationRectangle
        {
            set { this.destinationRectangle = value; }
            get { return this.destinationRectangle; }
        }
        public SpriteEffects Effect
        {
            set { this.effect = value; }
        }
        public float Rotation
        {
            set { this.rotation = value; }
        }

        // Constructor
        public ExplorerIdle(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                      (int)this.explorer.Position.Y,
                                                      this.explorer.Texture.Width / 4,
                                                      this.explorer.Texture.Height);

        }

        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        // Update
        public override void Update(GameTime gameTime)
        {
            if (Input.LevelDetectKeyDown(Keys.Right))
            {
                this.explorer.State = this.explorer.WalkRight;
            }
            else if (Input.LevelDetectKeyDown(Keys.Left))
            {
                this.explorer.State = this.explorer.WalkLeft;
            }
            else if (Input.LevelDetectKeyDown(Keys.Down))
            {
                this.explorer.State = this.explorer.WalkDown;
            }
            else if (Input.LevelDetectKeyDown(Keys.Up))
            {
                this.explorer.State = this.explorer.WalkUp;
            }
        }


        // Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
