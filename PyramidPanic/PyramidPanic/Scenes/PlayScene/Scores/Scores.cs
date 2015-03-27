﻿using System;
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
    public class Scores
    {
        // Fields
        private static int lives = 3;
        private static bool gameOver = false;

        // Properties
        public static int Lives
        {
            get { return lives; }
            set 
            { 
                  lives = value;
                  if (lives == 0)
                  {
                      gameOver = true;
                  }
            }
        }

        public static bool GameOver
        {
            get { return gameOver; }
        }
    }
}
