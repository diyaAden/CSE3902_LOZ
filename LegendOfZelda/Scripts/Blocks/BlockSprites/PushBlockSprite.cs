using LegendOfZelda.Scripts.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class PushBlockSprite : BasicBlock
    {
        private const int xPos = 18, yPos = 11, width = 16, height = 16, pushSpeed = 1;
        private readonly Vector2 permittedMovement = new Vector2(16, 16);
        private bool originSet = false;
        private Vector2 originalPos;
        public bool PushTriggerActive { get; set; } = false;
        public override Vector2 Position { 
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
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }
        public override void HandleCollision(ICollision side, int scale)
        {
            if (side is ICollision.SideTop && originalPos.Y - pos.Y <= permittedMovement.Y * scale)
            {
                pos.Y -= pushSpeed;
            }
            else if (side is ICollision.SideBottom && pos.Y - originalPos.Y <= permittedMovement.Y * scale)
            {
                pos.Y += pushSpeed;
            }
            else if (side is ICollision.SideLeft && originalPos.X - pos.X <= permittedMovement.X * scale)
            {
                pos.X -= pushSpeed;
            }
            else if (side is ICollision.SideRight && pos.X - originalPos.X <= permittedMovement.X * scale)
            {
                pos.X += pushSpeed;
            }
            DetectPushTrigger(scale);
        }
        private void DetectPushTrigger(int scale)
        {
            if (!PushTriggerActive)
            {
                if (Math.Abs(Position.X - originalPos.X) >= width * scale || Math.Abs(Position.Y - originalPos.Y) >= height * scale)
                {
                    PushTriggerActive = true;
                }
            }
        }

        public override void Update() { }
    }
}
