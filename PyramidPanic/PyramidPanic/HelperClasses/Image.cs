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
    public class Image
    {
        //Fields
        private Texture2D texture;
        private Vector2 position;
        private PyramidPanic game;
        private Rectangle rectangle;
        //Properties


        //Constructor
        public Image(PyramidPanic game, string pictureName, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = this.game.Content.Load<Texture2D>(@"Assets\" + pictureName);
            this.rectangle = new Rectangle((int)this.position.X,
                                           (int)this.position.Y,
                                           this.texture.Width,
                                           this.texture.Height);
        }

        //Update method


        //Draw method
        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.texture, this.rectangle, Color.White);
        }
    }
}
