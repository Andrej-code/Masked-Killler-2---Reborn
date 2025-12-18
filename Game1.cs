using Masked_Killler_2__Reborn;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
namespace Masked_Killler_2___Reborn
{

    enum Screens 
    { 
     Intro,
     Game
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Player

        List<Texture2D> survivorTextures;

        Survivor survivor;


        // Bot

        // Items

        Texture2D bloxyTexture;
        Rectangle bloxyRect;

        Texture2D gasTexture;
        Rectangle gasRect;

        Texture2D gunTexture;
        Rectangle gunRect;

        Texture2D medkitTexture;
        Rectangle medkitRect;

        // Background

        Texture2D campTexture;

        // Other

        Rectangle window;

        KeyboardState KeyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Other

            window = new Rectangle(0, 0, 800, 600);

            _graphics.PreferredBackBufferHeight = window.Height;

            _graphics.PreferredBackBufferWidth = window.Width;

            _graphics.ApplyChanges();

            survivorTextures = new List<Texture2D>();

            survivor = new Survivor(survivorTextures, new Rectangle(200, 200, 30, 40));

            bloxyRect = new Rectangle(100, 100, 30, 40);

            gasRect = new Rectangle(100, 150, 30, 40);

            gunRect = new Rectangle(100, 200, 30, 40);

            medkitRect = new Rectangle(100, 250, 30, 40);   

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Background
            campTexture = Content.Load<Texture2D>("Images/camp");


            // Player

            for(int i = 1; i <= 4; i++)
            {
                survivorTextures.Add(Content.Load<Texture2D>("Images/survivor_" + i));
            }

            // Items

            bloxyTexture = Content.Load<Texture2D>("Images/bloxyCola");

            gasTexture = Content.Load<Texture2D>("Images/gasCan");

            gunTexture = Content.Load<Texture2D>("Images/pistol");

            medkitTexture = Content.Load<Texture2D>("Images/medkit");
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            survivor.Update(window, KeyboardState);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // Background

            _spriteBatch.Draw(campTexture, window, Color.White);

            survivor.Draw(_spriteBatch);

            _spriteBatch.Draw(bloxyTexture, bloxyRect, Color.White);

            _spriteBatch.Draw(gasTexture, gasRect, Color.White);

            _spriteBatch.Draw(gunTexture, gunRect, Color.White);

            _spriteBatch.Draw(medkitTexture, medkitRect, Color.White);


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
