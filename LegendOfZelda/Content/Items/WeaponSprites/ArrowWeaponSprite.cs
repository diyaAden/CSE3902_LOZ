using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class ArrowWeaponSprite : BasicItem
    {
        public enum Direction { Up, Down, Left, Right}
        private Direction direction;
        private int speed = 2;
        
        public ArrowWeaponSprite(Texture2D itemSpriteSheet, Rectangle sourceRect, Direction movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(sourceRect);
            direction = movingDirection;
            timerLimit = 20;
        }

        public override void Update()
        {
            switch (direction)
            {
                case Direction.Up:
                    pos.Y -= speed;
                    break;
                case Direction.Right:
                    pos.X += speed;
                    break;
                case Direction.Down:
                    pos.Y += speed;
                    break;
                default:
                    pos.X -= speed;
                    break;
            }
        }
    }
}
