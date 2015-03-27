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
    public class LevelPause : ILevel
    {
        // Fields
        private Level level;
        private Image overlay, pauze;
        private float timer;

        // Properties

        // Constructor
        public LevelPause(Level level)
        {
            this.level = level;
            this.overlay = new Image(this.level.Game,
                                     @"PlayScenePics\Level\Overlay640x480White",
                                     Vector2.Zero,
                                     'q');
            this.pauze = new Image(this.level.Game,
                                     @"PlayScenePics\Level\pauze",
                                     Vector2.Zero,
                                     'q');
            this.overlay.Color = new Color(0, 0, 0, 80);
        }

        public void Update(GameTime gameTime)
        {
            /*
            this.timer += 1f / 60f;

            if (this.timer > 3)
            {
                this.level.LevelState = this.level.LevelPlay;
                this.timer = 0f;
            }
            */

            if (Input.EdgeDetectKeyDown(Keys.P))
            {
                this.level.LevelState = this.level.LevelPlay;
            }
        }

        public void Draw(GameTime gameTime)
        {
            this.overlay.Draw(gameTime);
            this.pauze.Draw(gameTime);
        }
    }
}
