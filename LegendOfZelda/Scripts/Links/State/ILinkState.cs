using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links
{
    public interface ILinkState
    {
        Vector2 Position { get; set; }
        int Direction { get; }
        void ToIdle();
        void ToDamaged();
        void MoveUp();
        void MoveDown();
        void MoveRight();
        void MoveLeft();
        void PositionUp();
        void PositionDown();
        void PositionRight();
        void PositionLeft();
        void UseItem();
        void PickItem(String name, int scale);
        void Attack();
        Rectangle LinkBox(int scale);
        void Update();
        void Draw(SpriteBatch spriteBatch, int scale);
    }
}
