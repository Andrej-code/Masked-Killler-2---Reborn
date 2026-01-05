using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masked_Killler_2__Reborn
{
    internal class Survivor
{

        private List<Texture2D> _survivorTextures;
        /* Index 0 - Up
         * Index 1 - Right
         * Index 2 - Down
         * Index 3 - Left
         */


        private Rectangle _location;
        private Vector2 _speed;
        private int _textureIndex;


        public Survivor(List<Texture2D> survivorTextures, Rectangle location)
        {
            _survivorTextures = survivorTextures;

            _location = location;

            _speed = new Vector2(0, 0);
            _textureIndex = 0;
        }

        public void Update(Rectangle window, KeyboardState keyboardState)
        {
            keyboardState = Keyboard.GetState();
            _speed = Vector2.Zero;

            if (_location.Y > 0)
            {
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    _speed.Y += -1;

                    _textureIndex = 0;

                }
            }

            if (_location.Bottom < window.Height)
            {
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    _speed.Y += 1;
                    _textureIndex = 2;
                }
            }

            if (_location.X > 0)
            {
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    _speed.X += -1;

                    _textureIndex = 3;
                }
            }

            if (_location.Right < window.Width)
            {
                if (keyboardState.IsKeyDown(Keys.D))
                {
                    _speed.X += 1;

                    _textureIndex = 1;

                }
            }

            // Speed is known.  Use if statements to determine which direction to face


            if (keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.D))
            {
                _textureIndex = 0;
            }

            if (keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.A))
            {
                _textureIndex = 0;
            }

            if (keyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyDown(Keys.D))
            {
                _textureIndex = 2;
            }

            if (keyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyDown(Keys.A))
            {
                _textureIndex = 2;
            }

            _location.Offset(_speed);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_survivorTextures[_textureIndex], _location, Color.White);
        }
}
}
