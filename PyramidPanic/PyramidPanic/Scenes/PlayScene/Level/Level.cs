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
    public class Level
    {
        // Fields
        private PyramidPanic game;
        private int levelIndex;
        private FileStream fileStream;
        private TextReader textReader;
        private List<string> lines;

        // Properties
        public PyramidPanic Game
        {
            get { return this.game;  }
        }
        public int LevelIndex
        {
            get { return this.levelIndex; }
            set { this.levelIndex = value;  }
        }


        // Constructor
        public Level(PyramidPanic game, int levelIndex)
        {
            this.game = game;
            this.levelIndex = levelIndex;
            this.lines = new List<string>();
            this.Initialize(levelIndex);
        }

        // Initialize
        public void Initialize(int levelIndex)
        {
            this.fileStream = File.OpenRead(@"C:\Users\Arjan de Ruijter\Documents\Visual Studio 2010\Projects\2014-2015\PyramidPanic\PyramidPanic\PyramidPanicContent\Assets\Level\" + levelIndex + ".txt");
            this.textReader = new StreamReader(this.fileStream);
            string line = this.textReader.ReadLine();

            while (line != null)
            {
                this.lines.Add(line);
                line = this.textReader.ReadLine();
            }

            foreach (string lineToConsole in this.lines)
            {
                Console.WriteLine(lineToConsole);
            }


            
        }


        // Update



        // Draw


        // Helper methods
    }
}
