using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Links
{
    public interface ILinkState
    {
        Vector2 Position { get; set; }
        int Direction { get; }
        void ToIdle();
        void ToDamaged();
        bool checkDamaged();
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
        void Attack(int scale);
        Rectangle LinkBox(int scale);
        void Update();
        void Draw(SpriteBatch spriteBatch, int scale);
    }
}
