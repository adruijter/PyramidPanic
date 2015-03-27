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
    public class LevelCollisionPause : ILevel
    {
        // Fields
        private Level level;
        private Image overlay;
        private float timer;

        // Properties

        // Constructor
        public LevelCollisionPause(Level level)
        {
            this.level = level;
            this.overlay = new Image(this.level.Game,
                                     @"PlayScenePics\Level\Overlay640x480White",
                                     Vector2.Zero,
                                     'q');
            this.overlay.Color = new Color(0, 0, 0, 80);
        }

        public void Update(GameTime gameTime)
        {
            this.timer += 1f / 60f;

            if (this.timer > 2)
            {
                ExplorerManager.CollisionDetectScorpions();
                this.level.LevelState = this.level.LevelPlay;
                this.timer = 0f;
            }
        }

        public void Draw(GameTime gameTime)
        {
            this.overlay.Draw(gameTime);
        }
    }
}
