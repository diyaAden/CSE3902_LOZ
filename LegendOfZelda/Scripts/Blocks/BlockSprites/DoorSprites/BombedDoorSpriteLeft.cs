using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class BombedDoorSpriteLeft : BasicBlock
    {
        public BombedDoorSpriteLeft(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(947, 77, 32, 32);
            transparency = 1f;
        }
        public override Rectangle ObjectBox(int scale)
        {
            return new Rectangle((int)pos.X + sourceRect.Width / 2 * scale, (int)pos.Y, sourceRect.Width / 2 * scale, sourceRect.Height * scale);
        }
        public override void Update()
        {

        }
    }
}
