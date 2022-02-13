using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class FireWeaponSprite : BasicItem
    {
        private int animationTimer = 0;
        
        public FireWeaponSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(17, 0, 16, 16));
        }

        public override void Update()
        {
            if (++animationTimer > 4)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}
