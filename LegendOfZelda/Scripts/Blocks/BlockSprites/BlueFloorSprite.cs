using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class BlueFloorSprite : BasicBlock
    {
        private const int xPos = 1, yPos = 11, width = 16, height = 16;

        public BlueFloorSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }

        public override void Update()
        {
            
        }
    }
}
