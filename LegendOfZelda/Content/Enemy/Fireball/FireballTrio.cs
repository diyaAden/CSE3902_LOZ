using Microsoft.Xna.Framework;
using LegendOfZelda.Content.Enemy.Fireball.Sprite;
using LegendOfZelda.Content.Enemy.Fireball.State;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Enemy.Fireball
{
    public class FireballTrio : IFireballTrio
    {
        public IFireballTrioState state { get; set; }
        private ISprite sprite;

        

        public FireballTrio(Game1 game, Vector2 position)
        {
            //IFireball fireball1;
            //IFireball fireball2;
            //IFireball fireball3;

            //Vector2 position1 = new Vector2(position.X, position.Y);
            //Vector2 position2 = new Vector2(position.X, position.Y - 10);
            //Vector2 position3 = new Vector2(position.X, position.Y - 20);

            



        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
