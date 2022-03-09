using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public abstract class BasicBoomerangWeapon : BasicItem
    {
        private const float rotationSpeed = 0.2f, minDistToLink = 3f;
        private bool returning = false;
        private float rotation = 0f;
        protected int direction;
        protected float acceleration;
        protected Vector2 speed, rotationOrigin;

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
                case 0:
                    pos.Y += (int)speed.Y;
                    break;
                case 1:
                    pos.Y -= (int)speed.Y;
                    break;
                case 2:
                    pos.X -= (int)speed.X;
                    break;
                default:
                    pos.X += (int)speed.X;
                    break;
            }
        }
        private void Return(Vector2 linkPosition)
        {
            if (Math.Abs(pos.X - linkPosition.X) < minDistToLink) { speed.X = 0; }
            else if (pos.X > linkPosition.X) { pos.X += (int)speed.X; }
            else { pos.X -= (int)speed.X; }

            if (Math.Abs(pos.Y - linkPosition.Y) < minDistToLink) { speed.Y = 0; }
            else if (pos.Y > linkPosition.Y) { pos.Y += (int)speed.Y; }
            else { pos.Y -= (int)speed.Y; }
        }
        public override void Update(Vector2 linkPosition)
        {
            if (!returning) { ThrowAway(); }
            else { Return(linkPosition); }

            UpdateFields(linkPosition);
        }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, animationFrames[currentFrame].Width * scale, animationFrames[currentFrame].Height * scale);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White, rotation, rotationOrigin, SpriteEffects.None, 0f);
        }
    }
}
