using LegendOfZelda.Scripts.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class PushBlockSprite : BasicBlock
    {
        private readonly int pushSpeed = 1;
        private bool originSet = false;
        private Vector2 originalPos;

        public override Vector2 position { 
            get { 
                return pos;
            } 
            set { 
                pos = value;
                if (!originSet)
                {
                    originalPos = new Vector2(pos.X, pos.Y);
                    originSet = true;
                }
            } 
        }

        public PushBlockSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(18, 11, 16, 16);
            transparency = 1f;
        }
        public override void HandleCollision(ICollision side, int scale)
        {
            if (side is ICollision.SideTop && originalPos.Y - pos.Y <= 16 * scale)
            {
                pos.Y -= pushSpeed;
            }
            else if (side is ICollision.SideBottom && pos.Y - originalPos.Y <= 16 * scale)
            {
                pos.Y += pushSpeed;
            }
            else if (side is ICollision.SideLeft && originalPos.X - pos.X <= 16 * scale)
            {
                pos.X -= pushSpeed;
            }
            else if (side is ICollision.SideRight && pos.X - originalPos.X <= 16 * scale)
            {
                pos.X += pushSpeed;
            }
        }

        public override void Update()
        {
            
        }
    }
}
