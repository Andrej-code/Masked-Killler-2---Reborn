
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

    public Enitiy(List<Texture2D> textures, Rectangle loaction)
    {

            _textures = textures;
            _speed = Vector2.Zero;
            _location = loaction;
            _textureIndex = 0;
    }

        public void Update( GameTime gameTime, Survivor survivor)
        {
            _speed = Vector2.Zero;


            if (survivor.Speed < _location.X)
            {
                _speed.X = -3;
                _textureIndex = 1;
            }

            if (survivor.Speed > _location.X)
            {
                _speed.X = 3;
                _textureIndex = 2;
            }

            if (survivor.Speed < _location.Y)
            {
                _speed.Y = 3;
                _textureIndex = 3;
            }

            if (survivor.Speed > _location.Y)
            {
                _speed.Y = -3;
                _textureIndex = 0;
            }

            _location.Offset(_speed);
        }

        public bool Contains (Point survivor)
        {
            return (_location.Contains(survivor));
        }

        public bool Intersects (Rectangle survivor)
        {
            return (_location.Intersects(survivor));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[_textureIndex],_location, Color.White);
        }

    }
}
