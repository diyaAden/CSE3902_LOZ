using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class BlackBackgroundSprite : BasicBlock
    {
        public BlackBackgroundSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(1, 28, 16, 16);
            transparency = 1f;
        }

        public override void Update()
        {
            
        }
    }
}
