using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy.Goriya.Sprite
{
    class MoveDownGoriyaSprite : Enemy
    {
        private int animationTimer = 0;

        public MoveDownGoriyaSprite(Texture2D itemSpriteSheet, int moveSpeed)
        {
            MoveSpeed = moveSpeed;
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(16, 0, 16, 16));
        }

        public override void Update(int scale)
        {
            if (++animationTimer > 4)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
            position = new Vector2(position.X, position.Y + MoveSpeed * scale);

        }
    }
}

