using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class EmptyWallHalfWidthSprite: BasicBlock
    {
        public EmptyWallHalfWidthSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(1, 11, 16, 64);
        }

        public override void Update()
        {

        }
    }
    
}
