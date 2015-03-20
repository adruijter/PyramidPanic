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
    public class Panel
    {
        // Fields
        private PyramidPanic game;
        private Vector2 position;
        private Char character;
        private List<Image> panelImages;
        private Image panel;

        // Properties


        // Constructor
        public Panel(PyramidPanic game, Vector2 position, Char character)
        {
            this.game = game;
            this.position = position;
            this.character = character;
            this.LoadContent();
        }

        private void LoadContent()
        {
            this.panelImages = new List<Image>();
            this.panelImages.Add(new Image(this.game, @"PlayScenePics\Panel\Panel", this.position, this.character));

        }

        // Methods
        public void Draw(GameTime gameTime)
        {
            foreach()
            {

            }
            
            this.panel.Draw(gameTime);
        }
    }
}
