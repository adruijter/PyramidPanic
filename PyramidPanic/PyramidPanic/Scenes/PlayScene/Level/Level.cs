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
        private Block testBlock;
        private Block[,] block;
        private int blockWidth;

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
            int blockWidth = line.Length;


            while (line != null)
            {
                this.lines.Add(line);
                line = this.textReader.ReadLine();
            }

            int blockHeight = this.lines.Count;

            this.fileStream.Close();
            this.textReader.Close();

            this.testBlock = new Block(this.game, @"PlayScenePics\Wall2", Vector2.Zero);

            this.block = new Block[blockWidth, blockHeight];

            for (int rowNumber = 0; rowNumber < blockHeight; rowNumber++)
            {
                for (int columnNumber = 0; columnNumber < blockWidth; columnNumber++)
                {
                    Char blockElement = this.lines[rowNumber][columnNumber];
                    this.block[columnNumber, rowNumber] = this.LoadBlock(blockElement, columnNumber, rowNumber);
                }
            }
        }


        private Block LoadBlock(Char blockElement, int x, int y)
        {
            switch (blockElement)
            {
                case '1':
                    return new Block(this.game, @"PlayScenePics\Wall2", new Vector2(x * 32f, y * 32f));
                default:
                    return new Block(this.game, @"PlayScenePics\Transparant", new Vector2(x * 32f, y * 32f));
            }

        }

        // Update

        // Draw
        public void Draw(GameTime gameTime)
        {
            this.testBlock.Draw(gameTime);
            for (int row = 0; row < this.lines.Count; row++)
            {
                for (int column = 0; column < this.blockWidth; column++)
                {
                    this.block[column, row].Draw(gameTime);
                }
            }
        }



        // Helper methods
    }
}
