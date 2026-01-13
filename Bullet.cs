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

        private Texture2D _bullet;
        private Rectangle _location;
        private Vector2 _speed;


        public Bullet(Texture2D bullet, Rectangle location)
        {
            _bullet = bullet;

            _location = location;

            _speed = new Vector2(0, 0);
        }

        public void Update(Rectangle window,  MouseState mouseState)
        {
            mouseState = Mouse.GetState();
            _speed = Vector2.Zero;


        }



}
}
