using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponCreators;

namespace LegendOfZelda.Scripts.Enemy.Goriya.Sprite
{
     class BasicGoriyaSprite : Enemy
    {
        private readonly int moveSpeed = 1;
        private int animationTimer = 0, direction;
        private IWeapon boomerang;
        private IEnemy sprite;
        private bool attacking = false;

        public override Vector2 position { 
            get { 
                return pos; 
            } 
            set { 
                pos = value;
                sprite.position = value;
            } 
        }
        public BasicGoriyaSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite(moveSpeed);
            MoveSpeed = 0;
            direction = 0;
        }

        public override void Attack()
        {
            attacking = true;
            boomerang = new BoomerangWeapon(pos, direction);
        }
        public override void Update(int scale)
        {
            if (!attacking)
            {
                sprite.Update(scale);
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
            if (boomerang != null && boomerang.GetWeaponType() == IWeapon.WeaponType.BOOMERANG) 
                boomerang.Update(pos);
            else 
                attacking = false;
        }
        private void NewDirection()
        {
            var rand = new Random();
            switch (rand.Next(4))
            {
                case 0:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite(moveSpeed);
                    direction = 0;
                    break;
                case 1:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaUpSprite(moveSpeed);
                    direction = 1;
                    break;
                case 2:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaLeftSprite(moveSpeed);
                    direction = 2;
                    break;
                default:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite(moveSpeed);
                    direction = 3;
                    break;
            }
            sprite.position = pos;
        }

        public override Rectangle ObjectBox(int scale) { return sprite.ObjectBox(scale); }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            sprite.Draw(spriteBatch, scale);
            if (boomerang != null)
            {
                boomerang.Draw(spriteBatch, scale);
            }
        }
    }
}

