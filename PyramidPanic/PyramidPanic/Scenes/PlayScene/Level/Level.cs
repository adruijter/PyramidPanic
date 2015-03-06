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
        private Block[,] block;
        private int blockWidth;
        private Image background;
        private List<Image> treasures;
        private List<Scorpion> scorpions;
        private ScorpionManager scorpionManager;
        private Explorer explorer;

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
        public List<Scorpion> Scorpions
        {
            get { return this.scorpions; }
        }
        public Block[,] Block
        {
            get { return this.block;  }
        }


        // Constructor
        public Level(PyramidPanic game, int levelIndex)
        {
            this.game = game;
            this.levelIndex = levelIndex;
            this.lines = new List<string>();
            this.treasures = new List<Image>();
            this.scorpions = new List<Scorpion>();
            this.Initialize(levelIndex);
            this.scorpionManager = new ScorpionManager(this);
        }

        // Initialize
        public void Initialize(int levelIndex)
        {
            this.fileStream = File.OpenRead(@"C:\Users\Arjan de Ruijter\Documents\Visual Studio 2010\Projects\2014-2015\PyramidPanic\PyramidPanic\PyramidPanicContent\Assets\Level\" + levelIndex + ".txt");
            this.textReader = new StreamReader(this.fileStream);
            
            string line = this.textReader.ReadLine();
            this.blockWidth = line.Length;


            while (line != null)
            {
                this.lines.Add(line);
                line = this.textReader.ReadLine();
            }

            int blockHeight = this.lines.Count;

            this.fileStream.Close();
            this.textReader.Close();

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
                    return new Block(this.game, @"PlayScenePics\Blocks\Wall2", new Vector2(x * 32f, y * 32f), false);
                case '2':
                    return new Block(this.game, @"PlayScenePics\Blocks\Block", new Vector2(x * 32f, y * 32f), false);
                case '3':
                    return new Block(this.game, @"PlayScenePics\Blocks\Door", new Vector2(x * 32f, y * 32f), false);
                case '4':
                    return new Block(this.game, @"PlayScenePics\Blocks\Wall1", new Vector2(x * 32f, y * 32f), false);
                case '@':
                    this.background = new Image(this.game, @"PlayScenePics\Background", new Vector2(0f, 0f));
                    return new Block(this.game, @"PlayScenePics\Blocks\Block", new Vector2(x * 32f, y * 32f), false);
                case 'a':
                    this.treasures.Add(new Image(this.game, @"PlayScenePics\Treasures\Ankh", 
                                                    new Vector2(x * 32f, y * 32f)));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true);
                case 'p':
                    this.treasures.Add(new Image(this.game, @"PlayScenePics\Treasures\Potion",
                                                    new Vector2(x * 32f, y * 32f)));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true);
                case 'c':
                    this.treasures.Add(new Image(this.game, @"PlayScenePics\Treasures\Cat",
                                                    new Vector2(x * 32f, y * 32f)));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true);
                case 's':
                    this.treasures.Add(new Image(this.game, @"PlayScenePics\Treasures\Scarab",
                                                    new Vector2(x * 32f, y * 32f)));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true);
                case 'S':
                    this.scorpions.Add(new Scorpion(this.game, new Vector2(x * 32f + 16f, y * 32f + 16f)));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true);
                case 'E':
                    this.explorer = new Explorer(this.game, new Vector2(x * 32f , y * 32f));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true);
                default:
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true);
            }

        }

        // Update
        public void Update(GameTime gameTime)
        {
            foreach (Scorpion scorpion in this.scorpions)
            {
                scorpion.Update(gameTime);
            }
            this.explorer.Update(gameTime);
        }

        // Draw
        public void Draw(GameTime gameTime)
        {
            //Dit is de achtergrond
            this.background.Draw(gameTime);


            for (int row = 0; row < this.lines.Count; row++)
            {
                for (int column = 0; column < this.blockWidth; column++)
                {
                    this.block[column, row].Draw(gameTime);
                }
            }

            foreach (Image treasure in this.treasures)
            {
                treasure.Draw(gameTime);
            }

            foreach (Scorpion scorpion in this.scorpions)
            {
                scorpion.Draw(gameTime);
            }
            this.explorer.Draw(gameTime);
        }



        // Helper methods
    }
}
