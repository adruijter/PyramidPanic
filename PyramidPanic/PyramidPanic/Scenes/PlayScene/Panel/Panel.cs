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
        private SpriteFont arial;
        private Vector2 livesExplorerOffset = new Vector2(3.6f * 32f, 1f);
        private Vector2 pointsOffset = new Vector2(16.5f * 32f, 1f);

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
            this.arial = this.game.Content.Load<SpriteFont>(@"Assets\PlayScenePics\Fonts\Arial");
            this.panelImages = new List<Image>();
            this.panelImages.Add(new Image(this.game, 
                                           @"PlayScenePics\Panel\Panel",
                                           this.position, 
                                           this.character));
            this.panelImages.Add(new Image(this.game, 
                                           @"PlayScenePics\Panel\Lives",
                                           this.position + new Vector2(2.5f * 32f, 0f), 
                                           this.character));

        }

        // Methods
        public void Draw(GameTime gameTime)
        {
            foreach(Image jan in this.panelImages )
            {
                jan.Draw(gameTime);
            }
            this.game.SpriteBatch.DrawString(this.arial,
                                             Scores.Lives.ToString(),
                                             this.position + this.livesExplorerOffset,
                                             Color.Gold);
            this.game.SpriteBatch.DrawString(this.arial,
                                             Scores.Points.ToString(),
                                             this.position + this.pointsOffset,
                                             Color.Gold);
        }
    }
}
