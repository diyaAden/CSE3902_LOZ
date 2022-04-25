using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy
{
    class MoveDownDarknutSprite : Enemy
    {
        private int animationTimer = 0;

        public MoveDownDarknutSprite(Texture2D itemSpriteSheet, int moveSpeed)
        {
            MoveSpeed = moveSpeed;
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, itemSpriteSheet.Height));
            animationFrames.Add(new Rectangle(0, 0, 16, itemSpriteSheet.Height));
        }

        public override void Update(int scale, Vector2 screenOffset)
        {
           if (++animationTimer > 4)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
            position = MovesPastWallsTest(screenOffset, new Vector2(position.X, position.Y + MoveSpeed * 1), scale);
        }
        public void Draw(SpriteBatch spriteBatch, int scale, Color drawColor)
        {
            this.drawColor = drawColor;
            base.Draw(spriteBatch, scale);
        }
    }
}

