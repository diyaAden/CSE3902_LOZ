using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class SquareBlockSprite : BasicBlock
    {
        public SquareBlockSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(18, 11, 16, 16);
            transparency = 1f;
        }

        public override void Update()
        {
            
        }
    }
}
