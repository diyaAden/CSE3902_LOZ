using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class EmptyWallFullWidthSprite: BasicBlock
    {
        public EmptyWallFullWidthSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(1, 11, 16, 144);
            transparency = 0;
        }

        public override void Update()
        {

        }
    }
    
}
