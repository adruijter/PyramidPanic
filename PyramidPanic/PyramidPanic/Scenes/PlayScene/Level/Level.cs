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
        private Panel panel;
        private ILevel levelState;
        private LevelPlay levelPlay;
        private LevelPause levelPause;
        private LevelCollisionPause levelCollisionPause;
        private LevelGameOver levelGameOver;
        private LevelNextLevel levelNextLevel;


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
        public List<Image> Treasures
        {
            get { return this.treasures; }
        }
        public Block[,] Block
        {
            get { return this.block;  }
        }
        public Explorer Explorer
        {
            get { return this.explorer; }
        }
        public ILevel LevelState
        {
            get { return this.levelState; }
            set { this.levelState = value; }
        }
        public LevelPlay LevelPlay
        {
            get { return this.levelPlay; }
        }
        public LevelPause LevelPause
        {
            get { return this.levelPause; }
        }
        public LevelCollisionPause LevelCollisionPause
        {
            get { return this.levelCollisionPause; }
        }
        public LevelGameOver LevelGameOver
        {
            get { return this.levelGameOver; }
        }
        public LevelNextLevel LevelNextLevel
        {
            get { return this.levelNextLevel; }
        }


        // Constructor
        public Level(PyramidPanic game, int levelIndex)
        {
            this.game = game;

            this.Initialize(levelIndex);
            
            this.levelPlay = new LevelPlay(this);
            this.levelPause = new LevelPause(this);
            this.levelCollisionPause = new LevelCollisionPause(this);
            this.levelGameOver = new LevelGameOver(this);
            this.levelNextLevel = new LevelNextLevel(this);
            this.levelState = this.levelPlay;
        }

        // Initialize
        public void Initialize(int levelIndex)
        {
            this.levelIndex = levelIndex;
            Scores.OpenDoors = false;
            this.lines = new List<string>();
            this.treasures = new List<Image>();
            this.scorpions = new List<Scorpion>();
            
            
            
            this.fileStream = File.OpenRead(@"C:\Users\Arjan de Ruijter\Documents\Visual Studio 2010\Projects\2014-2015\PyramidPanic\PyramidPanic\PyramidPanicContent\Assets\LevelMapDesign\" + levelIndex + ".txt");
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
            this.CountTotalPointsLevel();
            this.scorpionManager = new ScorpionManager(this);
            ExplorerManager.Level = this;
        }


        private Block LoadBlock(Char blockElement, int x, int y)
        {
            switch (blockElement)
            {
                case '1':
                    return new Block(this.game, @"PlayScenePics\Blocks\Wall2", new Vector2(x * 32f, y * 32f), false, '1');
                case '2':
                    return new Block(this.game, @"PlayScenePics\Blocks\Block", new Vector2(x * 32f, y * 32f), false, '2');
                case '3':
                    return new Block(this.game, @"PlayScenePics\Blocks\Door", new Vector2(x * 32f, y * 32f), false, '3');
                case '4':
                    return new Block(this.game, @"PlayScenePics\Blocks\Wall1", new Vector2(x * 32f, y * 32f), false, '4');
                case '@':
                    this.background = new Image(this.game, @"PlayScenePics\Background", new Vector2(0f, 0f), '@');
                    return new Block(this.game, @"PlayScenePics\Blocks\Block", new Vector2(x * 32f, y * 32f), false, '2');
                case 'a':
                    this.treasures.Add(new Image(this.game, @"PlayScenePics\Treasures\Ankh", 
                                                    new Vector2(x * 32f, y * 32f), 'a'));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true, 't');
                case 'p':
                    this.treasures.Add(new Image(this.game, @"PlayScenePics\Treasures\Potion",
                                                    new Vector2(x * 32f, y * 32f), 'p'));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true, 't');
                case 'c':
                    this.treasures.Add(new Image(this.game, @"PlayScenePics\Treasures\Cat",
                                                    new Vector2(x * 32f, y * 32f), 'c'));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true, 't');
                case 's':
                    this.treasures.Add(new Image(this.game, @"PlayScenePics\Treasures\Scarab",
                                                    new Vector2(x * 32f, y * 32f), 's'));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true, 't');
                case 'S':
                    this.scorpions.Add(new Scorpion(this.game, new Vector2(x * 32f + 16f, y * 32f + 16f)));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true, 't');
                case 'E':
                    this.explorer = new Explorer(this.game, new Vector2(x * 32f + 16f , y * 32f + 16f));
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true, 't');
                case 'P':
                    this.panel = new Panel(this.game, new Vector2(x * 32f, y * 32f), 'P');
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true, 't');
                default:
                    return new Block(this.game, @"PlayScenePics\Blocks\Transparant", new Vector2(x * 32f, y * 32f), true, 't');
            }

        }

        private void CountTotalPointsLevel()
        {
            int totalPointsLevel = 0;
            foreach (Image image in treasures)
            {
                switch (image.Character)
                {
                    case 'a':
                        totalPointsLevel += 10;
                        break;
                    case 'c':
                        totalPointsLevel += 100;
                        break;
                    case 's':
                        totalPointsLevel += 50;
                        break;
                    default:
                        break;
                }
            }
            Scores.MinimalPointsForNextLevel = Scores.Points + (int)(totalPointsLevel * 0.5f);
            Console.WriteLine("MinimalPointsForNextLevel: {0}", Scores.MinimalPointsForNextLevel);
        }

        // Update
        public void Update(GameTime gameTime)
        {            
            this.levelState.Update(gameTime);
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
                //treasure.Color = Color.Violet;
                treasure.Draw(gameTime);
            }

            foreach (Scorpion scorpion in this.scorpions)
            {
                scorpion.Draw(gameTime);
            }
            this.explorer.Draw(gameTime);
            this.panel.Draw(gameTime);
            this.levelState.Draw(gameTime);
        }
    }
}
