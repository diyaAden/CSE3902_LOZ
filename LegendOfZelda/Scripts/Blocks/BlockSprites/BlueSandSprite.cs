using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class BlueSandSprite : BasicBlock
    {
        public BlueSandSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(18, 28, 16, 16);
            transparency = 1f;
        }

        public override void Update()
        {
            
        }
    }
}
