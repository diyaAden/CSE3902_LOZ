using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class CompassSprite : BasicItem
    {
        
        public CompassSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(62, 0, 11, 12));
        }

        public override void Update()
        {
            
        }
    }
}
