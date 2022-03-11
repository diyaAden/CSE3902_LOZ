using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class HeartSprite : BasicItem
    {
        public HeartSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 7, 8));
            animationFrames.Add(new Rectangle(0, 9, 7, 8));
            name = "Heart";
            animationTimer = 0;
        }

        public override void Update()
        {
            if (++animationTimer > 7)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}
