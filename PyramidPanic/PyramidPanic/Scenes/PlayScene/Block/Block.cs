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
    public class Block : Image
    {
        // Fields
        private bool passable;
        
        // Properties
        public bool Passable
        {
            get { return this.passable; }
        }
        public Rectangle CollisionRectangle
        {
            get { return this.Rectangle; }
        }


        // Constructor
        public Block(PyramidPanic game, string pictureName, Vector2 position, bool passable)
            : base(game, pictureName, position)
        {
            this.passable = passable;
            this.Color = Color.White;
        }


        // Update


        // Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
