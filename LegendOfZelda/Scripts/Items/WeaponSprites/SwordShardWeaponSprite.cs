using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class SwordShardWeaponSprite : BasicItem
    {
        private readonly int directionX = 1, directionY = 1;
        private const int speed = 1, xPos1 = 0, xPos2 = 8, yPos = 10, width = 8, height = 10;

        public SwordShardWeaponSprite(Texture2D shardSpriteSheet, int row)
        {
            // int row corresponds with row in spritesheet and determines movement direction:
            // 0 = NW, 1 = SW, 2 = NE, 3 = SE
            spriteSheet = shardSpriteSheet;
            animationFrames.Add(new Rectangle(xPos1, yPos * row, width, height));
            animationFrames.Add(new Rectangle(xPos2, yPos * row, width, height));
            animationTimer = 0;

            if (row <= 1) directionX = -1;
            if (row % 2 == 0) directionY = -1;
        }

        public override void Update()
        {
            if (++animationTimer > 1)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
            pos.X += speed * directionX;
            pos.Y += speed * directionY;
        }
    }
}
