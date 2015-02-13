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
    public class Scorpion
    {
        // Fields
        private PyramidPanic game;
        private Vector2 position;
        private Texture2D texture;
        private Rectangle destinationRectangle, sourceRectangle;
        private float timer = 0f;
        private IState state;
        private WalkRight walkRight;

        // Properties


        // Constructor
        public Scorpion(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = this.game.Content.Load<Texture2D>(@"Assets\PlayScenePics\Scorpion\Scorpion");
            this.destinationRectangle = new Rectangle((int)position.X,
                                                      (int)position.Y,
                                                      this.texture.Width/4,
                                                      this.texture.Height);
            this.sourceRectangle = new Rectangle(0, 0, this.texture.Width/4, this.texture.Height);
            this.walkRight = new WalkRight(this);
            this.state = this.walkRight;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            if (this.timer > 5f / 60f)
            {
                if (this.sourceRectangle.X < 96)
                {
                    this.sourceRectangle.X += 32;
                }
                else
                {
                    this.sourceRectangle.X = 0;
                }
                this.timer = 0f;
            }
            this.timer += 1f / 60f;
        }

        // Draw
        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.texture,
                                    this.destinationRectangle,
                                    this.sourceRectangle,
                                    Color.White,
                                    0f,
                                    Vector2.Zero,
                                    SpriteEffects.None,
                                    0f);                                  
        }
    }
}
