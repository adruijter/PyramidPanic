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
    public class Menu
    {
        //Fields
        private PyramidPanic game;
        private Image start, help, Load, quit, scores, editor;
        private List<Image> buttonList;


        //Properties


        //Constructor
        public Menu(PyramidPanic game)
        {
            this.game = game;


            this.Initialize();
        }

        private void Initialize()
        {


            this.LoadContent();
        }

        private void LoadContent()
        {
            this.start = new Image(this.game, @"StartScenePics\Button_Start",
                                            new Vector2(15f, 433f));
        }


        //Update
        public void Update(GameTime gameTime)
        {

        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.start.Draw(gameTime);
        }
    }
}
