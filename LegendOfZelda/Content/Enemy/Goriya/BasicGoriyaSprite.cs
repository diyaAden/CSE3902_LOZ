using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Content.Items;

namespace LegendOfZelda.Content.Enemy.Goriya.Sprite
{
     class BasicGoriyaSprite : Enemy
    {

        private int animationTimer = 0, currentFrame = 0;
        private List<Rectangle> animationFrames = new List<Rectangle>();
        private List<IItem> boomerangs = new List<IItem>();


        public BasicGoriyaSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(16, 0, 16, 16));
        }

        public override void Attack()
        {

            boomerangs.Add(WeaponSpriteFactory.Instance.CreateWoodBoomerangWeaponSprite(1));
        }
        public override void Update()
        {
            var rand = new Random();
            if (++animationTimer > 4)
            {
                currentFrame = ++currentFrame % animationFrames.Count;
                if (animationTimer == 160)
                {
                    animationTimer = 0;
                    Attack();
                }
            }
            foreach (IItem item in boomerangs) {
                item.Update();
            }
            //position = new Vector2(position.X + (rand.Next(-2, 2)), position.Y + (rand.Next(-2, 2)));

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }
    }
}

