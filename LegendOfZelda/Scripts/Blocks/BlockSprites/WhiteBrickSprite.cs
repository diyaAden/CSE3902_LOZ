using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class WhiteBrickSprite : BasicBlock
    {
        public WhiteBrickSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(1, 45, 16, 16);
        }

        public override void Update()
        {
            
        }
    }
}
