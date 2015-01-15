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
        //Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private PlayScene playScene;
        private QuitScene quitscene;
        private HelpScene helpScene;
        private LoadScene loadScene;
        private ScoreScene scoreScene;
        private StartScene startScene;
        private IState iState;
        

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

            this.iState = quitscene;
        }

        protected override void UnloadContent()
        {
           
        }
       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();            

            this.iState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            this.iState.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
