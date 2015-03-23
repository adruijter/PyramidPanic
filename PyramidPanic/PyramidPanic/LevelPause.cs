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

        // Properties

        // Constructor
        public LevelPause(Level level)
        {
            this.level = level;
        }

        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.P))
            {
                this.level.LevelState = this.level.LevelPlay;
            }
        }

        public void Draw(GameTime gameTime)
        {

        }
    }
}
