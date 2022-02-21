using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Enemy.Fireball.State
{
    
        public interface IFireballTrioState
        {
            void MoveUp();
            void MoveDown();
            void MoveRight();
            void MoveLeft();
            void UseItem();
            void Attack();
            void Update();
            void Draw(SpriteBatch spriteBatch);
        }
    
}
