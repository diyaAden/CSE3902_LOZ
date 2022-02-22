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
        private IEnemy sprite;
        private bool attacking = false;


        public BasicGoriyaSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();

        }

        public override void Attack()
        {
            attacking = true;
            boomerangs.Add(WeaponSpriteFactory.Instance.CreateWoodBoomerangWeaponSprite(1));
        }
        public override void Update()
        {
            sprite.Update();
            pos = sprite.position;
            if (++animationTimer == 150)
            {
                animationTimer = 0;
                Attack();
            }
            else if (animationTimer % 30 == 0) {
                if (attacking) attacking = false;
                else NewDirection(); 
            }
            foreach (IItem item in boomerangs) {
                item.Update();
            }
        }
        private void NewDirection()
        {
            var rand = new Random();
            switch (rand.Next(4))
            {
                case 0:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
                    break;
                case 1:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaUpSprite();
                    break;
                case 2:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaLeftSprite();
                    break;
                default:
                    sprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
                    break;
            }
            sprite.position = pos;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}

