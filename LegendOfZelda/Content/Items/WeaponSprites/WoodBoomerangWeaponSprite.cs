using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class WoodBoomerangWeaponSprite : BasicItem
    {
        private Vector2 speed = new Vector2(3, 3);
        private int acceleration = 1;
        private int direction;
        private int timer = 0;
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

        public override void Update()
        {
            rotation += rotationSpeed;
            switch (direction)
            {
                case 1:
                    pos.Y -= speed.Y;
                    break;
                case 3:
                    pos.X += speed.X;
                    break;
                case 0:
                    pos.Y += speed.Y;
                    break;
                default:
                    pos.X -= speed.X;
                    break;
            }
            if (++timer == 9)
            {
                timer = 0;
                speed.X -= acceleration;
                speed.Y -= acceleration;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White, rotation, rotationOrigin, SpriteEffects.None, 0f);
        }
    }
}
