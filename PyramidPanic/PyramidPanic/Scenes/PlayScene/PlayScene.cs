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
    public class PlayScene : IState
    {
        //Fields
        private PyramidPanic game;
        private Level level;

        //Properties


        //Constructor
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            this.level = new Level(this.game, 0);
        }

        // Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                this.game.IState = this.game.StartScene;
            }

            this.level.Update(gameTime);
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.BlanchedAlmond);
            this.level.Draw(gameTime);
        }
    }
}
