using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponCreators;

namespace LegendOfZelda.Scripts.Enemy.Goriya.Sprite
{
     class BasicGoriyaSprite : Enemy
    {

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
            if (boomerang != null && boomerang.GetWeaponType() == IWeapon.WeaponType.BOOMERANG) boomerang.Update(pos);
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

