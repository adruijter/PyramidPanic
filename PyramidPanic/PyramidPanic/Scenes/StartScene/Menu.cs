﻿using System;
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
            
        }


        //Update
        public void Update(GameTime gameTime)
        {
            if (this.start.Rectangle.Intersects(Input.MouseRectangle))
            {
                this.start.Color = Color.Gold;
            }
            else if (this.help.Rectangle.Intersects(Input.MouseRectangle))
            {
                this.help.Color = Color.Gold;
            }
            else if (this.scores.Rectangle.Intersects(Input.MouseRectangle))
            {
                this.scores.Color = Color.Gold;
            }
            else if (this.quit.Rectangle.Intersects(Input.MouseRectangle))
            {
                this.quit.Color = Color.Gold;
            }
            else if (this.editor.Rectangle.Intersects(Input.MouseRectangle))
            {
                this.editor.Color = Color.Gold;
            }
            else
            {
                foreach (Image button in this.buttonList)
                {
                    button.Color = Color.White;
                }
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
