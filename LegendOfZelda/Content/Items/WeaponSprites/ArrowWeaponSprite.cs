using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class ArrowWeaponSprite : BasicItem
    {
        public enum Direction { Up, Down, Left, Right}
        private Direction direction;
        private int speed = 2;
        
        public ArrowWeaponSprite(Texture2D itemSpriteSheet, Direction movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            direction = movingDirection;
            timerLimit = 20;
            switch (direction)
            {
                case Direction.Up:
                    animationFrames.Add(new Rectangle(52, 0, 5, 16));
                    break;
                case Direction.Right:
                    //fill
                    break;
                case Direction.Down:
                    //fill
                    break;
                default:
                    //fill
                    break;
            }
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
