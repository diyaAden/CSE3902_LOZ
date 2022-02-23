using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class RupeeSprite : BasicItem
    {
        private int animationTimer = 0;
        
        public RupeeSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 8, 16));
            animationFrames.Add(new Rectangle(9, 0, 8, 16));
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
