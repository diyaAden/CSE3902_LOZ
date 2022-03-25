using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class EmptyWallFullLenSprite: BasicBlock
    {
        private const int xPos = 1, yPos = 11, width = 224, height = 16;

        public EmptyWallFullLenSprite(Texture2D wallSpriteSheet)
        {
            spriteSheet = wallSpriteSheet;
            sourceRect = new Rectangle(xPos, yPos, width, height);
            transparency = 0;
        }

        public override void Update()
        {

        }
    }
    
}
