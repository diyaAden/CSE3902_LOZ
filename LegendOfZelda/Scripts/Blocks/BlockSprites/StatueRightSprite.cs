using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class StatueRightSprite : BasicBlock
    {
        public StatueRightSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(35, 11, 16, 16);
        }

        public override void Update()
        {
            
        }
    }
}
