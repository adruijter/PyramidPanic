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
    public class Scorpion : IEntity
    {
        // Fields
        private PyramidPanic game;
        private Vector2 position;
        private Texture2D texture, collisionTexture;
        private float leftBorder, rightBorder;       
        private IAnimatedSprite state;
        private WalkRight walkRight;
        private WalkLeft walkLeft;
        private Vector2 speed = new Vector2(1f, 0f);
        private Rectangle collisionRectangle;


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
                  this.collisionRectangle = new Rectangle((int)this.position.X - 16,
                                                          (int)this.position.Y - 16,
                                                          this.collisionTexture.Width,
                                                          this.collisionTexture.Height);
                }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public float LeftBorder
        {
            get { return this.leftBorder; }
            set { this.leftBorder = value; }
        }
        public float RightBorder
        {
            get { return this.rightBorder; }
            set { this.rightBorder = value; }
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
        public Vector2 Speed
        {
            get { return this.speed; } 
        }
        public Rectangle CollisionRectangle
        {
            get { return this.collisionRectangle; }
        }


        // Constructor
        public Scorpion(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = this.game.Content.Load<Texture2D>(@"Assets\PlayScenePics\Scorpion\Scorpion");
            this.collisionTexture = this.game.Content.
                                    Load<Texture2D>(@"Assets\PlayScenePics\32x32-white");
            this.collisionRectangle = new Rectangle((int)position.X - 16,
                                                    (int)position.Y - 16,
                                                    this.texture.Width/4,
                                                    this.texture.Height);
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
            this.game.SpriteBatch.Draw(this.collisionTexture,
                                       this.collisionRectangle,
                                       Color.YellowGreen);
        }
    }
}
