using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class BlueSandSprite : BasicBlock
    {
        private const int xPos = 18, yPos = 28, width = 16, height = 16;

        public BlueSandSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }

        public override void Update()
        {
            
        }
    }
}
