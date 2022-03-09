using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class OpenDoorSpriteUp : BasicBlock
    {
        public OpenDoorSpriteUp(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(848, 110, 32, 32);
            transparency = 1f;
        }

        public override void Update()
        {

        }
    }
}
