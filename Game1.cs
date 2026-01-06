using Masked_Killler_2__Reborn;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
namespace Masked_Killler_2___Reborn
{

    enum Screen
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
        List<Rectangle> gases;

        Texture2D gunTexture;
        Rectangle gunRect;

        Texture2D medkitTexture;
        Rectangle medkitRect;

        // Background

        Texture2D campTexture;

        Texture2D mK2rTexture;

        // Other

        Rectangle window;

        KeyboardState keyboardState;

        Random generator;

        Screen screen;

        SpriteFont titlefont;

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

            generator = new Random();

            window = new Rectangle(0, 0, 800, 600);

            _graphics.PreferredBackBufferHeight = window.Height;

            _graphics.PreferredBackBufferWidth = window.Width;

            _graphics.ApplyChanges();

            screen = new Screen();

            // Assests

            survivorTextures = new List<Texture2D>();

            survivor = new Survivor(survivorTextures, new Rectangle(200, 200, 30, 40));

            bloxyRect = new Rectangle(100, 100, 30, 40);

            gases = new List<Rectangle>();

            for (int i = 0; i < 5; i++)
            {
                gases.Add(new Rectangle(generator.Next(0, window.Width - 20), generator.Next(0, window.Height - 30), 20, 30));
            }

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

            mK2rTexture = Content.Load<Texture2D>("Images/MK2R");


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

            // Text

            titlefont = Content.Load<SpriteFont>("Text/titlefont");
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            keyboardState = Keyboard.GetState();

            if (screen == Screen.Intro)
            {
                if(keyboardState.IsKeyDown(Keys.Enter))
                {
                    screen = Screen.Game;
                }
            }

            survivor.Update(window, keyboardState);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // Background

            if(screen == Screen.Intro)
            {

                _spriteBatch.Draw(mK2rTexture, window, Color.White);
                _spriteBatch.DrawString(titlefont,"Press Enter to Start", new Vector2(200,150), Color.Red);

            }

            else if (screen == Screen.Game)
            {
                _spriteBatch.Draw(campTexture, window, Color.White);

            // Player

           
                survivor.Draw(_spriteBatch);

            // Items

                _spriteBatch.Draw(bloxyTexture, bloxyRect, Color.White);

                foreach (Rectangle gasCan in gases)
                {
                    _spriteBatch.Draw(gasTexture, gasCan, Color.White);

                }

                _spriteBatch.Draw(gunTexture, gunRect, Color.White);

                _spriteBatch.Draw(medkitTexture, medkitRect, Color.White);

            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
