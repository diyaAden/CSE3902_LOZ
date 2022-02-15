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
        
        public WoodBoomerangWeaponSprite(Texture2D itemSpriteSheet, int facing)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(129, 3, 5, 8));
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
