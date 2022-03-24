using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class SquareBlockSprite : BasicBlock
    {
        private const int xPos = 18, yPos = 11, width = 16, height = 16;

        public SquareBlockSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }

        public override void Update()
        {
            
        }
    }
}
