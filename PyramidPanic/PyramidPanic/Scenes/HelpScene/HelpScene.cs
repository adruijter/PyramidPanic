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
    public class HelpScene : IState
    {
        //Fields
        private PyramidPanic game;
        private Image helpText;
        private Vector2 scrollSpeed;

        //Properties


        //Constructor
        public HelpScene(PyramidPanic game)
        {
            this.game = game;
            this.helpText = new Image(this.game, @"HelpScenePics\HelpText", new Vector2(0f, 0f));
            this.scrollSpeed = new Vector2(0f, 20f);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                this.game.IState = this.game.StartScene;
            }

            if (Input.LevelDetectKeyDown(Keys.Down) || (Input.MouseScroll() == "down"))
            {
                if ( this.helpText.Position.Y > (-1000 + 480))
                this.helpText.Position -= this.scrollSpeed;
            }

            if (Input.LevelDetectKeyDown(Keys.Up) || (Input.MouseScroll() == "up"))
            {
                if (this.helpText.Position.Y < 0)
                    this.helpText.Position += this.scrollSpeed;
            }

            Input.MouseScroll();
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Red);
            this.helpText.Draw(gameTime);
        }
    }
}
