using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class BlueGapSprite : BasicBlock
    {
        public BlueGapSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(35, 28, 16, 16);
        }

        public override void Update()
        {
            
        }
    }
}
