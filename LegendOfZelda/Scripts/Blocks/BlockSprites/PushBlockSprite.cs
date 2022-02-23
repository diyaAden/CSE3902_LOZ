using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Blocks.BlockSprites
{
    class PushBlockSprite : BasicBlock
    {
        public PushBlockSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(18, 11, 16, 16);
        }

        public override void Update()
        {
            
        }
    }
}
