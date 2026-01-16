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
    internal class Bullet
{

        private Texture2D _bulletTexture;
        private Rectangle _location;
        private Vector2 _speed;

        public Bullet (Texture2D bulletTexture, Rectangle location, Vector2 speed)
        {
            _bulletTexture = bulletTexture;
            _speed = speed;
            _location = location;
        }


        public void Update(Rectangle window)
        {
            
          _location.Offset(_speed);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_bulletTexture,_location, Color.White);
        }
        public Rectangle Location
        {
            get { return _location; }
            set { _location = value; }
        }

    }
}
