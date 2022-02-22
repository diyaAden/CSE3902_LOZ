using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Items.WeaponCreators;

namespace LegendOfZelda.Content.Enemy.Goriya.Sprite
{
     class BasicGoriyaSprite : Enemy
    {

        private int animationTimer = 0, currentFrame = 0, direction;
        private List<Rectangle> animationFrames = new List<Rectangle>();
        private IWeapon boomerang;
        private IEnemy sprite;
        private bool attacking = false;


        public BasicGoriyaSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
            direction = 0;
        }

        public override void Attack()
        {
            attacking = true;
            boomerang = new BoomerangWeapon(pos, direction);
        }
        public override void Update()
        {
            if (!attacking)
            {
                sprite.Update();
                pos = sprite.position;
                if (++animationTimer == 150)
                {
                    animationTimer = 0;
                    Attack();
                }
                else if (animationTimer % 30 == 0)
                {
                    NewDirection();
                }
            }
            if (boomerang != null) boomerang.Update(pos);
            else attacking = false;
        }
        private void NewDirection()
        {
            var rand = new Random();
            switch (rand.Next(4))
            {
                case 0:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
                    direction = 0;
                    break;
                case 1:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaUpSprite();
                    direction = 1;
                    break;
                case 2:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaLeftSprite();
                    direction = 2;
                    break;
                default:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
                    direction = 3;
                    break;
            }
            sprite.position = pos;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            if (boomerang != null)
            {
                boomerang.Draw(spriteBatch);
            }
        }
    }
}

