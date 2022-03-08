using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class EmptyWallHalfLenSprite: BasicBlock
    {
        public EmptyWallHalfLenSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(1, 11, 100, 16);
        }

        public override void Update()
        {

        }
    }
    
}
