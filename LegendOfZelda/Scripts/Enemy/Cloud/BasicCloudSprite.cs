using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy
{
    class BasicCloudSprite : Enemy
    {

        private int animationTimer = 0;
        private int moveSpeed = 1;

        public BasicCloudSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(16, 0, 16, 16));
            animationFrames.Add(new Rectangle(32, 0, 16, 16));
            animationFrames.Add(new Rectangle(48, 0, 16, 16));
            MoveSpeed = moveSpeed;
            Health = 1; //Not find online.
        }
        public override void HandleWeaponCollision(IGameObject weapon, ICollision side) { }

        public override void Update(int scale, Vector2 screenOffset)
        {
            if (++animationTimer > 10)
            {
                animationTimer = 0;
                if (++currentFrame == animationFrames.Count) Health = 0;
                currentFrame %= animationFrames.Count;
            }

        }
    }
}

