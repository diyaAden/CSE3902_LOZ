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
        public override Rectangle ObjectBox(int scale)
        {
            return new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width / 2 * scale, sourceRect.Height * scale);
        }
        public override void Update() { }
        public override void Draw(SpriteBatch spriteBatch, int scale) { }
    }
}
