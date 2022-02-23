using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class StairsSprite : BasicBlock
    {
        public StairsSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(52, 28, 16, 16);
        }

        public override void Update()
        {
            
        }
    }
}
