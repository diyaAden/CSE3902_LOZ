using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class MagicBoomerangWeaponSprite : BasicItem
    {
        private Vector2 speed = new Vector2(6, 6);
        private int acceleration = 2;
        private int direction;
        private int timer = 0;

        public MagicBoomerangWeaponSprite(Texture2D itemSpriteSheet, int facing)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(129, 19, 5, 8));
            direction = facing;
            timerLimit = 60;
        }

        public override void Update()
        {
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
    }
}
