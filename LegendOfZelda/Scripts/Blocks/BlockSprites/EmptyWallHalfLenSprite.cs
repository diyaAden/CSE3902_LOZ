using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class EmptyWallHalfLenSprite: BasicBlock
    {
        private const int xPos = 1, yPos = 11, width = 100, height = 16;

        public EmptyWallHalfLenSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(xPos, yPos, width, height);
            transparency = 0;
        }

        public override void Update()
        {

        }
    }
    
}
