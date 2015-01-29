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
    public class Menu
    {
        //Fields
        private enum Button { Start, Help, Scores, Quit, Editor };
                            //  0      1      2      3      4
        private Button buttonActive = Button.Start;

        private PyramidPanic game;
        private Image start, load, help, scores, quit, editor;
        private List<Image> buttonList;
        private float offsetLeft, offsetDown, buttonWidth, spacing;


        //Properties


        //Constructor
        public Menu(PyramidPanic game)
        {
            this.game = game;


            this.Initialize();
        }

        private void Initialize()
        {
            this.offsetLeft = 15f;
            this.offsetDown = 433f;
            this.buttonWidth = 100f;
            this.spacing = 28f;

            this.LoadContent();
        }

        private void LoadContent()
        {
            this.buttonList = new List<Image>();

            this.buttonList.Add(this.start = new Image(this.game,
                                                       @"StartScenePics\Button_start",
                                                       new Vector2(this.offsetLeft, this.offsetDown)));
            
            this.buttonList.Add(this.help = new Image(this.game, 
                                                      @"StartScenePics\Button_help",
                                                      new Vector2(this.offsetLeft + 
                                                      1 * (this.buttonWidth + this.spacing), this.offsetDown)));


            this.buttonList.Add(this.scores = new Image(this.game,
                                                        @"StartScenePics\Button_scores",
                                                        new Vector2(this.offsetLeft +
                                                        2 * (this.buttonWidth + this.spacing),
                                                        this.offsetDown)));

            this.buttonList.Add(this.quit = new Image(this.game, 
                                                      @"StartScenePics\Button_quit",
                                                      new Vector2(this.offsetLeft +
                                                      3 * (this.buttonWidth + this.spacing),
                                                      this.offsetDown)));

            this.buttonList.Add(this.editor = new Image(this.game, 
                                                        @"StartScenePics\Button_leveleditor",
                                                        new Vector2(this.offsetLeft +
                                                        4 * (this.buttonWidth + this.spacing),
                                                        this.offsetDown)));
            this.start.Color = Color.Gold;
        }


        //Update
        public void Update(GameTime gameTime)
        {
            //als je op de right knop drukt wordt de knop rechts naast de actieve Goudkleurig
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                if ((int)this.buttonActive < 4)
                {
                    this.buttonActive++;
                }
            }

            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                if (this.buttonActive > 0)
                {
                    this.buttonActive--;
                }
            }           
            
            //Als je op de left knop drukt wordt de knop links naast de actieve knop goedkleurig
            
            
            if (this.start.Rectangle.Intersects(Input.MouseRectangle))
            {
                if (Input.MouseClickLeft())
                {
                   this.game.IState = this.game.PlayScene;
                }
                ResetButtonColor();
                this.buttonActive = Button.Start;
                this.start.Color = Color.Gold;
            }
            else if (this.help.Rectangle.Intersects(Input.MouseRectangle))
            {
                if (Input.MouseClickLeft())
                {
                    this.game.IState = this.game.HelpScene;
                }
                ResetButtonColor();
                this.buttonActive = Button.Help;
                this.help.Color = Color.Gold;
            }
            else if (this.scores.Rectangle.Intersects(Input.MouseRectangle))
            {
                if (Input.MouseClickLeft())
                {
                    this.game.IState = this.game.ScoreScene;
                }
                ResetButtonColor();
                this.buttonActive = Button.Scores;
                this.scores.Color = Color.Gold;
            }
            else if (this.quit.Rectangle.Intersects(Input.MouseRectangle))
            {
                if (Input.MouseClickLeft())
                {
                    this.game.IState = this.game.QuitScene;
                }
                ResetButtonColor();
                this.buttonActive = Button.Quit;
                this.quit.Color = Color.Gold;
            }
            else if (this.editor.Rectangle.Intersects(Input.MouseRectangle))
            {
                if (Input.MouseClickLeft())
                {
                    this.game.IState = this.game.LevelEditorScene;
                }
                ResetButtonColor();
                this.buttonActive = Button.Editor;
                this.editor.Color = Color.Gold;
            }
            else
            {
                ResetButtonColor();

                switch (this.buttonActive)
                {
                    case Button.Start:
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            //Als dit zo is dat code voor het veranderen van scene
                            this.game.IState = this.game.PlayScene ;
                        }  
                        this.start.Color = Color.Gold;
                        break;
                    case Button.Help:
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            //Als dit zo is dat code voor het veranderen van scene
                            this.game.IState = this.game.HelpScene;
                        }
                        this.help.Color = Color.Gold;
                        break;
                    case Button.Quit:
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            //Als dit zo is dat code voor het veranderen van scene
                            this.game.IState = this.game.QuitScene;
                        }
                        this.quit.Color = Color.Gold;
                        break;
                    case Button.Scores:
                        //Hier komt code om te detecteren of er op de entertoets gedrukt wordt.
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            //Als dit zo is dat code voor het veranderen van scene
                            this.game.IState = this.game.ScoreScene;
                        }                        
                        this.scores.Color = Color.Gold;
                        break;
                    case Button.Editor:
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            //Als dit zo is dat code voor het veranderen van scene
                            this.game.IState = this.game.LevelEditorScene;
                        }
                        this.editor.Color = Color.Gold;
                        break;
                }
            }
        }

        private void ResetButtonColor()
        {
            foreach (Image button in this.buttonList)
            {
                button.Color = Color.White;
            }
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            foreach (Image button in this.buttonList)
            {
                button.Draw(gameTime);
            }
        }
    }
}
