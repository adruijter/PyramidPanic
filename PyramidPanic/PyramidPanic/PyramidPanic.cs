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
   public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PlayScene playScene;
        QuitScene quitscene;
        HelpScene helpScene;
        LoadScene loadScene;
        ScoreScene scoreScene;
        StartScene startScene;
        

        public PyramidPanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            IsMouseVisible = true;
            Window.Title = "Pyramid Panic Beta 0.000.00.000.001";
        }
        
        protected override void Initialize()
        {
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.playScene = new PlayScene(this);
            this.quitscene = new QuitScene(this);
            this.helpScene = new HelpScene(this);
            this.loadScene = new LoadScene(this);
            this.scoreScene = new ScoreScene(this);
            this.startScene = new StartScene(this);
        }

        protected override void UnloadContent()
        {
           
        }
       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            this.playScene.Update(gameTime);
            this.quitscene.Update(gameTime);
            this.helpScene.Update(gameTime);
            this.loadScene.Update(gameTime);
            this.scoreScene.Update(gameTime);
            this.startScene.Update(gameTime);

            // this.state.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this.playScene.Draw(gameTime);
            this.quitscene.Draw(gameTime);
            this.helpScene.Draw(gameTime);
            this.loadScene.Draw(gameTime);
            this.scoreScene.Draw(gameTime);
            this.startScene.Draw(gameTime);

            // this.state.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
