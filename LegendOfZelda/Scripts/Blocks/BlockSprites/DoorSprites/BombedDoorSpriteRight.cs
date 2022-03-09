using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class BombedDoorSpriteRight : BasicBlock
    {
        public BombedDoorSpriteRight(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(947, 44, 32, 32);
            transparency = 1f;
        }

        public override void Update()
        {

        }
    }
}
