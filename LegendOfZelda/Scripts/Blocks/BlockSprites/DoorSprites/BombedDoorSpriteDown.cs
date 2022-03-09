using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class BombedDoorSpriteDown : BasicBlock
    {
        public BombedDoorSpriteDown(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(947, 110, 32, 32);
            transparency = 1f;
        }

        public override void Update()
        {

        }
    }
}
