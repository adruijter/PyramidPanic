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
        private float leftBorder = 32f, rightBorder = 576f;
        
        
        private IAnimatedSprite state;
        private WalkRight walkRight;
        private WalkLeft walkLeft;

        // Properties
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value;
                  this.state.DestinationRectangle = new Rectangle((int)this.position.X,
                                                                      (int)this.position.Y,
                                                                      this.texture.Width/4,
                                                                      this.texture.Height);
                }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public float LeftBorder
        {
            get { return this.leftBorder; }
        }
        public float RightBorder
        {
            get { return this.rightBorder; }
        }
        public IAnimatedSprite State
        {
            set { 
                    this.state = value;
                    this.state.Initialize();
                }
        }
        public WalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }
        public WalkRight WalkRight
        {
            get { return this.walkRight; }
        }


        // Constructor
        public Scorpion(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = this.game.Content.Load<Texture2D>(@"Assets\PlayScenePics\Scorpion\Scorpion");
            this.walkLeft = new WalkLeft(this);
            this.walkRight = new WalkRight(this);
            this.state = this.walkRight;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }

        // Draw
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);                       
        }
    }
}
