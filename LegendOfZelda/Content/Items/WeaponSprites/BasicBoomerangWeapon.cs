using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public abstract class BasicBoomerangWeapon : BasicItem
    {
        private const float rotationSpeed = 0.2f;
        private const float minDistToLink = 3f;

        private bool returning = false;
        private float rotation = 0f;

        protected int direction;
        protected float acceleration;
        protected Vector2 speed;
        protected Vector2 rotationOrigin;

        private void UpdateFields(Vector2 linkPosition)
        {
            if (returning && Math.Abs(pos.X - linkPosition.X) < minDistToLink && Math.Abs(pos.Y - linkPosition.Y) < minDistToLink)
            {
                timerLimit = 0;
            }
            rotation += rotationSpeed;
            speed.X -= acceleration;
            speed.Y -= acceleration;
            if (!returning && speed.X < 0 && speed.Y < 0)
            {
                returning = true;
            }
        }

        private void ThrowAway()
        {
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
        }

        public override void Update(Vector2 linkPosition)
        {
            if (!returning)
            {
                ThrowAway();
            }
            else
            {
                if (Math.Abs(pos.X - linkPosition.X) < minDistToLink)
                {
                    speed.X = 0;
                }
                else if (pos.X > linkPosition.X)
                {
                    pos.X += (int)speed.X;
                }
                else
                {
                    pos.X -= (int)speed.X;
                }
                if (Math.Abs(pos.Y - linkPosition.Y) < minDistToLink)
                {
                    speed.Y = 0;
                }
                else if (pos.Y > linkPosition.Y)
                {
                    pos.Y += (int)speed.Y;
                }
                else
                {
                    pos.Y -= (int)speed.Y;
                }
            }
            UpdateFields(linkPosition);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White, rotation, rotationOrigin, SpriteEffects.None, 0f);
        }
    }
}
