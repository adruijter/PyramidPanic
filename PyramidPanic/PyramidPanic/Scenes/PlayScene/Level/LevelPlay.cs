using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{ 
    public class LevelPlay : ILevel
    {
        // Fields
        private Level level;

        // Properties


        // Constructor
        public LevelPlay(Level level)
        {
            this.level = level;
        }

        public void Update(GameTime gameTime)
        {
            ExplorerManager.WalkOutOfLevel();            
            if (Scores.GameOver)
            {
                this.level.LevelState = level.LevelGameOver;
            }
            
            if (Input.EdgeDetectKeyDown(Keys.P))
            {
                this.level.LevelState = this.level.LevelPause;
            }

            foreach (Scorpion scorpion in this.level.Scorpions)
            {
                scorpion.Update(gameTime);
            }
            this.level.Explorer.Update(gameTime);
            ExplorerManager.CollisionDetectScorpions();
            ExplorerManager.OpenDoors();

        }

        public void Draw(GameTime gameTime)
        {

        }
    }
}
