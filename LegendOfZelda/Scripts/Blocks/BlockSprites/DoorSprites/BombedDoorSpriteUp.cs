using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class BombedDoorSpriteUp : BasicBlock
    {
        public BombedDoorSpriteUp(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(947, 11, 32, 32);
            transparency = 1f;
        }
        public override Rectangle ObjectBox(int scale)
        {
            return new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height / 2 * scale);
        }
        public override void Update()
        {

        }
    }
}
