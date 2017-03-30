using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PerishedEngine.GameLevels;
using PerishedEngine.Managers;
using PerishedEngine.UI.UIScreens;

namespace PerishedEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Set the resolution of the window
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            //Sets the window attributes
            this.Window.Title = "GAME TITLE!!!";

            this.IsMouseVisible = true;

            LevelManager.Instance.Initialize(new GameLevel());
            GameManager.Instance.game = this;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ResourceManager.Instance.LoadAllContent(Content);
            GraphicsManager.Instance.Initialize(spriteBatch);
            GraphicsManager.Instance.LoadContent();
            GraphicsManager.Instance.windowWidth = graphics.PreferredBackBufferWidth;
            GraphicsManager.Instance.windowHeight = graphics.PreferredBackBufferHeight;

            LevelManager.Instance.currentLevel.LoadContent();
            UIManager.Instance.ChangeCanvas(new UIPlayground());
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            LevelManager.Instance.currentLevel.Update(gameTime);

            if (UIManager.Instance.currentScreen != null)
                UIManager.Instance.currentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            LevelManager.Instance.currentLevel.Draw(spriteBatch);

            if (UIManager.Instance.currentScreen != null)
                UIManager.Instance.currentScreen.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}