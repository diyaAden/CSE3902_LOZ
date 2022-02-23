using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class MapSprite : BasicItem
    {
        
        public MapSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(12, 0, 8, 16));
        }

        public override void Update()
        {
            
        }
    }
}
