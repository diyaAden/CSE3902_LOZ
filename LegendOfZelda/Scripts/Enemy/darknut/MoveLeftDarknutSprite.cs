using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy
{
    class MoveLeftDarknutSprite : Enemy
    {
        private int animationTimer = 0;

        public MoveLeftDarknutSprite(Texture2D itemSpriteSheet, int moveSpeed)
        {
            MoveSpeed = moveSpeed;
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(16, 0, 16, 16));
        }

        public override void Update(int scale, Vector2 screenOffset)
        {
            if (++animationTimer > 4)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
            position = MovesPastWallsTest(screenOffset, new Vector2(position.X - MoveSpeed * 1, position.Y), scale);
        }
        public void Draw(SpriteBatch spriteBatch, int scale, Color drawColor)
        {
            this.drawColor = drawColor;
            base.Draw(spriteBatch, scale);
        }
    }
}

