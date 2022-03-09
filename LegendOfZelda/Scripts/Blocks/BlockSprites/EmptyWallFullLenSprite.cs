using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class EmptyWallFullLenSprite: BasicBlock
    {
        public EmptyWallFullLenSprite(Texture2D wallSpriteSheet)
        {
            spriteSheet = wallSpriteSheet;
            sourceRect = new Rectangle(1, 11, 200, 16);
            transparency = 0.1f;
        }

        public override void Update()
        {

        }
    }
    
}
