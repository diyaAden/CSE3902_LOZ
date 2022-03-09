using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class LockedDoorSpriteLeft : BasicBlock
    {
        public LockedDoorSpriteLeft(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(881, 77, 32, 32);
            transparency = 1f;
        }

        public override void Update()
        {

        }
    }
}
