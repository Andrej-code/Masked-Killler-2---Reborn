
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masked_Killler_2__Reborn
{
    public class Enitiy
    {
        private List<Texture2D> _textures;
        private Vector2 _speed;
        private Rectangle _location;
        private int _textureIndex;
        private bool _isPaused;

    public Enitiy(List<Texture2D> textures, Rectangle loaction)
    {

            _textures = textures;
            _speed = Vector2.Zero;
            _location = loaction;
            _textureIndex = 0;
            _isPaused = false;
    }

        public void Update( GameTime gameTime, Survivor survivor)
        {
            if (!_isPaused)
            {
                _speed = Vector2.Zero;

                // Right
                if (_location.X < survivor.Location.X)
                {
                    _speed.X = 1f;
                    _textureIndex = 1;
                }
                // Left
                if (_location.X > survivor.Location.X)
                {
                    _speed.X = -1f;
                    _textureIndex = 2;
                }
                // Down
                if (_location.Y < survivor.Location.Y)
                {
                    _speed.Y = 1f;
                    _textureIndex = 3;
                }
                // Up
                if (_location.Y > survivor.Location.Y)
                {
                    _speed.Y = -1f;
                    _textureIndex = 0;
                }


                _location.Offset(_speed);
            }
        }

       
        public Vector2 Direction
        {
            get { return _speed; }
        
        }

        public bool Intersects (Rectangle survivor)
        {
            return (_location.Intersects(survivor));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[_textureIndex],_location, Color.White);
        }
        public bool IsPaused
        {
            get { return _isPaused; }
            set { _isPaused = value; }
        }

    }
}
