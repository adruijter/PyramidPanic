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
        private LevelEditorScene levelEditorScene;

        KeyboardState ks, oks;
        int sceneListKey = 0;

        private List<IState> sceneList;
        private IState iState;

        //Properties
        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch; }
        }
        public IState IState
        {
            get { return this.iState; }
            set { this.iState = value; }
        }
        public PlayScene PlayScene
        {
            get { return this.playScene; }
        }
        public HelpScene HelpScene
        {
            get { return this.helpScene; }
        }
        

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
            this.sceneList = new List<IState>();

            this.playScene = new PlayScene(this);
            this.quitscene = new QuitScene(this);
            this.helpScene = new HelpScene(this);
            this.loadScene = new LoadScene(this);
            this.scoreScene = new ScoreScene(this);
            this.startScene = new StartScene(this);
            this.levelEditorScene = new LevelEditorScene(this);
           
            this.sceneList.Add(this.startScene);
            this.sceneList.Add(this.playScene);
            this.sceneList.Add(this.helpScene);
            this.sceneList.Add(this.loadScene);
            this.sceneList.Add(this.scoreScene);
            this.sceneList.Add(this.quitscene);
            this.sceneList.Add(this.levelEditorScene);

            this.iState = this.sceneList[this.sceneListKey];
        }

        protected override void UnloadContent()
        {
           
        }
       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            Input.Update(gameTime);

            /*
            ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right) && oks.IsKeyUp(Keys.Right))
            {
                if (this.sceneListKey < 6)
                {
                    this.sceneListKey++;
                }

                this.iState = this.sceneList[this.sceneListKey];
            }

            if (ks.IsKeyDown(Keys.Left) && oks.IsKeyUp(Keys.Left))
            {
                if (this.sceneListKey > 0)
                {
                    this.sceneListKey--;
                }

                this.iState = this.sceneList[this.sceneListKey];
            }

            
            oks = ks;
            */

            this.iState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();
            this.iState.Draw(gameTime);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
