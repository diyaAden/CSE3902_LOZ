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
        public override Rectangle ObjectBox(int scale)
        {
            return new Rectangle((int)pos.X, (int)pos.Y + sourceRect.Height / 2 * scale, sourceRect.Width * scale, sourceRect.Height / 2 * scale);
        }
        public override void Update()
        {

        }
    }
}
