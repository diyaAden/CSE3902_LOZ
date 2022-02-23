using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Blocks.BlockSprites
{
    class BlueFloorSprite : BasicBlock
    {
        public BlueFloorSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(1, 11, 16, 16);
        }

        public override void Update()
        {
            
        }
    }
}
