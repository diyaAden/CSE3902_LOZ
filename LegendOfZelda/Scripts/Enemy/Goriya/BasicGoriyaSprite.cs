using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Enemy.Goriya;
using LegendOfZelda.Scripts.Enemy.Goriya.Sprite;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Enemy
{
    class BasicGoriyaSprite : Enemy
    {
        private readonly int moveSpeed = 1;
        private readonly Random rnd = new Random();
        private readonly List<IEnemy> boomerang = new List<IEnemy>();
        private int animationTimer = 0, direction, attackTimer = 0, attackTimeLimit;
        private IEnemy sprite;
        private bool attacking = false;
        private Vector2 goriyaCenter;

        public override Vector2 position { 
            get { return pos; } 
            set { 
                pos = value;
                sprite.position = value;
            } 
        }
        public BasicGoriyaSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite(moveSpeed);
            MoveSpeed = moveSpeed;
            direction = 0;
            attackTimeLimit = rnd.Next(100, 181);
            Health = 3; //red is 3, blue is 5.
        }
        public override void HandleBlockCollision(IGameObject block, ICollision side, int scale)
        {
            sprite.HandleBlockCollision(block, side, scale);
            pos = sprite.position;
        }
        public override void Attack()
        {
            attacking = true;
            boomerang.Clear();
            boomerang.Add(new BoomerangEnemy(goriyaCenter, direction));
        }
        public override void Update(int scale, Vector2 screenOffset) { }
        public void Update(List<IEnemy> Enemies, int scale, Vector2 screenOffset)
        {
            
            if (!attacking && hurtCooldown == 0)
            {
                sprite.Update(scale, screenOffset);
                pos = sprite.position;
                if (++animationTimer == 30)
                {
                    animationTimer = 0;
                    NewDirection();
                }
                if (++attackTimer == attackTimeLimit)
                {
                    attackTimer = 0;
                    attackTimeLimit = rnd.Next(100, 181);
                    Attack();
                    foreach (IEnemy rang in boomerang) Enemies.Add(rang);
                }
            }
            goriyaCenter = new Vector2(pos.X + sprite.ObjectBox(scale).Width / 2f, pos.Y + sprite.ObjectBox(scale).Height / 2f);
            base.Update(scale, screenOffset);
            if (boomerang.Count > 0 && ((BoomerangEnemy)boomerang[0]).GetWeaponType() == IWeapon.WeaponType.BOOMERANG)
                boomerang[0].Update(goriyaCenter, scale, screenOffset);
            else
                attacking = false;
        }
        public override void HandleWeaponCollision(IGameObject weapon, ICollision side)
        {
            if (!(side is ICollision.SideNone) && hurtCooldown == 0)
            {
                hurtCooldown = hurtCooldownLimit;
                Health--;
                foreach (IEnemy rang in boomerang) rang.Health = 0;
            }
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
            foreach (IEnemy rang in boomerang) rang.Draw(spriteBatch, scale);
            sprite.Draw(spriteBatch, scale);
            if (sprite is MoveLeftGoriyaSprite) ((MoveLeftGoriyaSprite)sprite).Draw(spriteBatch, scale, drawColor);
            else if (sprite is MoveRightGoriyaSprite) ((MoveRightGoriyaSprite)sprite).Draw(spriteBatch, scale, drawColor);
            else if (sprite is MoveUpGoriyaSprite) ((MoveUpGoriyaSprite)sprite).Draw(spriteBatch, scale, drawColor);
            else if (sprite is MoveDownGoriyaSprite) ((MoveDownGoriyaSprite)sprite).Draw(spriteBatch, scale, drawColor);
        }
    }
}