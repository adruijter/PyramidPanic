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
    public class Explorer : IEntity
    {
        // Fields
        private PyramidPanic game;
        private Vector2 position;
        private Texture2D texture;      
        private IAnimatedSprite state;
        private ExplorerWalkRight walkRight;
        private ExplorerIdle idle;
        private ExplorerWalkLeft walkLeft;
        private ExplorerWalkDown walkDown;
        private ExplorerWalkUp walkUp;
        private float speed = 2f;
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
                                                          this.texture.Width / 4,
                                                          this.texture.Height);
                }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public IAnimatedSprite State
        {
            set { 
                    this.state = value;
                    this.state.Initialize();
                }
            get { return this.state; }
        }
        public ExplorerWalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }
        public ExplorerWalkRight WalkRight
        {
            get { return this.walkRight; }
        }
        public ExplorerIdle Idle
        {
            get { return this.idle; }
        }
        public ExplorerWalkDown WalkDown
        {
            get { return this.walkDown; }
        }
        public ExplorerWalkUp WalkUp
        {
            get { return this.walkUp; }
        }
        public float Speed
        {
            get { return this.speed; } 
        }
        public Rectangle CollisionRectangle
        {
            get { return this.collisionRectangle; }
            set { this.collisionRectangle = value; }
        }


        // Constructor
        public Explorer(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = this.game.Content.Load<Texture2D>(@"Assets\PlayScenePics\Explorer\Explorer");
            this.walkRight = new ExplorerWalkRight(this);
            this.idle = new ExplorerIdle(this);
            this.walkLeft = new ExplorerWalkLeft(this);
            this.walkDown = new ExplorerWalkDown(this);
            this.walkUp = new ExplorerWalkUp(this);
            this.state = this.idle;
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
