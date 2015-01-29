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
    public class QuitScene : IState
    {
        //Fields
        private PyramidPanic game;

        //Constructor
        public QuitScene(PyramidPanic game)
        {
            this.game = game;
        }

        public void Update(GameTime gameTime)
        {
            this.game.Exit();
        }

        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.BlueViolet);
        }
    }
}
