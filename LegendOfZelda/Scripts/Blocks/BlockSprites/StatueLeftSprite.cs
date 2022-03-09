using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class StatueLeftSprite : BasicBlock
    {
        public StatueLeftSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(52, 11, 16, 16);
            transparency = 1f;
        }

        public override void Update()
        {
            
        }
    }
}
