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
     Tips,
     Game,
     Win,
     Lose

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
        List<Rectangle> bloxys;

        Texture2D bloxyOutlineTexture;
        Rectangle bloxyOutlineRect;

        Texture2D gasTexture;
        List<Rectangle> gases;
        int gasScore;


        Texture2D gunTexture;
        Rectangle gunRect;

        Texture2D gunOutlineTexture;
        Rectangle gunOutlineRect;

        Texture2D medkitTexture;
        Rectangle medkitRect;

        Texture2D medkitOutlineTexture;
        Rectangle medkitOutlineRect;

        // Background

        Texture2D campTexture;

        Texture2D mK2rTexture;

        Texture2D diedTexture;

        Texture2D surviveTexture;

        // Other

        Rectangle window;

        KeyboardState keyboardState;

        Random generator;

        Screen screen;

        SpriteFont titlefont;

        bool speedBoost = false;


        float seconds;

        float secondsTimer;

        float secondsCola;

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

            seconds = 0f;

            secondsTimer = 0f;

            gasScore = 0;

            // Assests

            survivorTextures = new List<Texture2D>();

            survivor = new Survivor(survivorTextures, new Rectangle(200, 200, 30, 40));

            bloxys = new List<Rectangle>();

            for(int i = 0; i < 2; i++)
            {
                bloxys.Add(new Rectangle(generator.Next(0, window.Width - 30), generator.Next(0, window.Height - 40), 30, 40));
            }

            bloxyOutlineRect = new Rectangle(60, 555, 55, 58);

            gases = new List<Rectangle>();

            for (int i = 0; i < 5; i++)
            {
                gases.Add(new Rectangle(generator.Next(0, window.Width - 20), generator.Next(0, window.Height - 30), 20, 30));
            }

            gunRect = new Rectangle(100, 200, 30, 40);

            gunOutlineRect = new Rectangle(100,555, 66, 68);

            medkitRect = new Rectangle(100, 250, 30, 40);

            medkitOutlineRect = new Rectangle(160, 555, 55, 58);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Background

            campTexture = Content.Load<Texture2D>("Images/camp");

            mK2rTexture = Content.Load<Texture2D>("Images/MK2R");

            diedTexture = Content.Load<Texture2D>("Images/youDied");

            surviveTexture = Content.Load<Texture2D>("Images/youSurvive");

            // Player

            for(int i = 1; i <= 4; i++)
            {
                survivorTextures.Add(Content.Load<Texture2D>("Images/survivor_" + i));
            }

            // Items

            bloxyTexture = Content.Load<Texture2D>("Images/bloxyCola");

            bloxyOutlineTexture = Content.Load<Texture2D>("Images/bloxyColaOutline");

            gasTexture = Content.Load<Texture2D>("Images/gasCan");
           
            gunTexture = Content.Load<Texture2D>("Images/pistol");

            gunOutlineTexture = Content.Load<Texture2D>("Images/pistolOutline");

            medkitTexture = Content.Load<Texture2D>("Images/medkit");

            medkitOutlineTexture = Content.Load<Texture2D>("Images/medkitOutline");

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

            else if(screen == Screen.Game)
            {
                survivor.Update(window, keyboardState);
                secondsTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (secondsTimer > 180)
                {
                    screen = Screen.Lose;
                }
                // Gas Cans
                for (int i = 0; i < gases.Count; i++)
                {
                    if (survivor.Intersects(gases[i]))
                    {
                        gases.RemoveAt(i);
                        i--;

                        gasScore += 1;
                    }
                }
                if (gasScore == 5 )
                {
                    screen = Screen.Win;
                }

                // Bloxy Colas
                secondsCola += (float)gameTime.ElapsedGameTime.TotalSeconds;
                for (int i = 0; i < bloxys.Count; i++)
                {

                    if (survivor.Intersects(bloxys[i]))
                    {
                        bloxys.RemoveAt(i);
                        i--;

                        if (seconds >= 5)
                        {
                            speedBoost = true;
                        }

                    }
                }
                if(secondsTimer == 0f)
                {
                    screen = Screen.Lose;
                }


            }


            else if(screen == Screen.Win)
            {
                seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (seconds >= 1.2)
                {
                    seconds = 0f;

                    Exit();
                }
            }


            else if(screen == Screen.Lose)
            {
                seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (seconds >= 1.2)
                {
                    seconds = 0f;

                    Exit();
                }
            }

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
                _spriteBatch.DrawString(titlefont,"Press Enter to Start", new Vector2(155,164), Color.Red);

            }

            else if (screen == Screen.Game)
            {
                _spriteBatch.Draw(campTexture, window, Color.White);


            // Timer

                _spriteBatch.DrawString(titlefont, (180 - secondsTimer).ToString("Timer - 0:00"), new Vector2(500, 5), Color.Red);

            
            // Score


              _spriteBatch.DrawString(titlefont, gasScore.ToString(" Gas Cans: 0/5"), new Vector2(10, 5), Color.Red);


            // Player

                survivor.Draw(_spriteBatch);

                // Items
                foreach (Rectangle bloxyCola in bloxys)
                {
                    _spriteBatch.Draw(bloxyTexture, bloxyCola, Color.White);

                }

                //_spriteBatch.Draw(bloxyOutlineTexture, bloxyOutlineRect, Color.White);

                foreach (Rectangle gasCan in gases)
                {
                    _spriteBatch.Draw(gasTexture, gasCan, Color.White);
                     
                }

                _spriteBatch.Draw(gunTexture, gunRect, Color.White);

                _spriteBatch.Draw(gunOutlineTexture, gunOutlineRect, Color.White);

                _spriteBatch.Draw(medkitTexture, medkitRect, Color.White);

                _spriteBatch.Draw(medkitOutlineTexture, medkitOutlineRect, Color.White);

            }


            if (screen == Screen.Win)
            {
                _spriteBatch.Draw(surviveTexture, window, Color.White);
            }

            if (screen == Screen.Lose)
            {
                _spriteBatch.Draw(diedTexture, window, Color.White);
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
