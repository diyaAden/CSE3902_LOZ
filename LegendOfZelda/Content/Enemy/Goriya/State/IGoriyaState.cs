using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Goriya
{
    public interface IGoriyaState
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
