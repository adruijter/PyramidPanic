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
        
        
        private IState state;
        private WalkRight walkRight;

        // Properties
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public Vector2 Position
        {
            get { return this.position; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }


        // Constructor
        public Scorpion(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = this.game.Content.Load<Texture2D>(@"Assets\PlayScenePics\Scorpion\Scorpion");
            
            
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
