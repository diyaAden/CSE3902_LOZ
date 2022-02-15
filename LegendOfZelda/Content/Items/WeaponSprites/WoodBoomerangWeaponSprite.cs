using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class WoodBoomerangWeaponSprite : BasicItem
    {
        private Vector2 speed = new Vector2(4f, 4f);
        private float acceleration = 0.1f;
        private int direction;
        private float rotation = 0f;
        private float rotationSpeed = 0.2f;
        private Vector2 rotationOrigin;

        public WoodBoomerangWeaponSprite(Texture2D itemSpriteSheet, int facing)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(129, 3, 5, 8));
            direction = facing;
            timerLimit = 60; 
            rotationOrigin = new Vector2(animationFrames[0].Width / 2.0f, animationFrames[0].Height / 2.0f);
        }

        public override void Update(Vector2 linkPosition)
        {
            rotation += rotationSpeed;
            switch (direction)
            {
                case 1:
                    pos.Y -= (int)speed.Y;
                    break;
                case 3:
                    pos.X += (int)speed.X;
                    break;
                case 0:
                    pos.Y += (int)speed.Y;
                    break;
                default:
                    pos.X -= (int)speed.X;
                    break;
            }
            speed.X -= acceleration;
            speed.Y -= acceleration;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White, rotation, rotationOrigin, SpriteEffects.None, 0f);
        }
    }
}
