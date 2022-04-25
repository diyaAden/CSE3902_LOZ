using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Enemy.Goriya;
using LegendOfZelda.Scripts.Enemy.Goriya.Sprite;
using System.Collections.Generic;
using LegendOfZelda.Scripts.Links;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Enemy
{
    class BasicDarknutSprite : Enemy
    {
        private readonly int moveSpeed = 1;
        private readonly Random rnd = new Random();
        private readonly List<IEnemy> boomerang = new List<IEnemy>();
        private int animationTimer = 0, direction, attackTimer = 0, attackTimeLimit;
        private IEnemy sprite;
        private bool attacking = false;
        // private Vector2 goriyaCenter;
        ILinkState link;
        public Vector2 targetPos;
        public override Vector2 position
        {
            get { return pos; }
            set
            {
                pos = value;
                sprite.position = value;
            }
        }
        public BasicDarknutSprite()
        {
            sprite = EnemySpriteFactory.Instance.CreateDarknutDownSprite(moveSpeed);
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
           // boomerang.Clear();
           // boomerang.Add(new BoomerangEnemy(goriyaCenter, direction));
        }

        public void getTargetPos(Vector2 linkPos)
        {
            targetPos = linkPos;
        }
        public override void Update(int scale, Vector2 screenOffset) { }
        public void Update(List<IEnemy> Enemies, int scale, Vector2 screenOffset, Vector2 linkPos)
        {
            Debug.WriteLine(linkPos);
            getTargetPos(linkPos);
            if (hurtCooldown == 0)
            {
                sprite.Update(scale, screenOffset);
                pos = sprite.position;
                if (++animationTimer == 30)
                {
                    animationTimer = 0;
                    NewDirection(linkPos);
                }
              /*  if (++attackTimer == attackTimeLimit)
                {
                    attackTimer = 0;
                    attackTimeLimit = rnd.Next(100, 181);
                    Attack();
                    foreach (IEnemy rang in boomerang) Enemies.Add(rang);
                } */
            }
          //  goriyaCenter = new Vector2(pos.X + sprite.ObjectBox(scale).Width / 2f, pos.Y + sprite.ObjectBox(scale).Height / 2f);
            base.Update(scale, screenOffset);
           // if (boomerang.Count > 0 && ((BoomerangEnemy)boomerang[0]).GetWeaponType() == IWeapon.WeaponType.BOOMERANG)
              //  boomerang[0].Update(goriyaCenter, scale, screenOffset);
           // else
               // attacking = false;
        }
        public override void HandleWeaponCollision(IGameObject weapon, ICollision side)
        {
            if (!(side is ICollision.SideNone) && hurtCooldown == 0)
            {
                hurtCooldown = hurtCooldownLimit;
                Health--;
                //foreach (IEnemy rang in boomerang) rang.Health = 0;
            }
        }
        private void NewDirection(Vector2 linkPos)
        {
          //  Debug.WriteLine("should be moving ");
            getTargetPos(linkPos);
            if (Math.Abs(targetPos.X - pos.X) < 250 || Math.Abs(targetPos.Y - pos.Y) < 200)
           // {
              //  Debug.WriteLine("should be moving ");
                //if to the left
                if (targetPos.X < pos.X)
                {
                    Debug.WriteLine("check A");
                    sprite = EnemySpriteFactory.Instance.CreateDarknutLeftSprite(moveSpeed);
                    direction = 2;
                    if (targetPos.Y < pos.Y)
                    {
                        Debug.WriteLine("check B");
                        sprite = EnemySpriteFactory.Instance.CreateDarknutUpSprite(moveSpeed);
                        direction = 1;
                    }
                    //if below
                    if (targetPos.Y > pos.Y)
                    {
                        sprite = EnemySpriteFactory.Instance.CreateDarknutDownSprite(moveSpeed);
                        direction = 0;
                    }
                }

                //if to the right
                if (targetPos.X > pos.X)
                {
                    sprite = EnemySpriteFactory.Instance.CreateDarknutRightSprite(moveSpeed);
                    direction = 3;
                    if (targetPos.Y < pos.Y)
                    {
                        sprite = EnemySpriteFactory.Instance.CreateDarknutUpSprite(moveSpeed);
                        direction = 1;
                    }
                    //if below
                    if (targetPos.Y > pos.Y)
                    {
                        sprite = EnemySpriteFactory.Instance.CreateDarknutDownSprite(moveSpeed);
                        direction = 0;
                    }
            }
                //if above
             /*   if (targetPos.Y < pos.Y)
                {
                    sprite = EnemySpriteFactory.Instance.CreateDarknutUpSprite(moveSpeed);
                    direction = 1;
                }
                //if below
                if (targetPos.Y > pos.Y)
                {
                    sprite = EnemySpriteFactory.Instance.CreateDarknutDownSprite(moveSpeed);
                    direction = 0;
                } */
          //  }
            sprite.position = pos;
        }

        public override Rectangle ObjectBox(int scale) { return sprite.ObjectBox(scale); }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            //foreach (IEnemy rang in boomerang) rang.Draw(spriteBatch, scale);
            sprite.Draw(spriteBatch, scale);
            if (sprite is MoveLeftDarknutSprite) ((MoveLeftDarknutSprite)sprite).Draw(spriteBatch, scale, drawColor);
            else if (sprite is MoveRightDarknutSprite) ((MoveRightDarknutSprite)sprite).Draw(spriteBatch, scale, drawColor);
            else if (sprite is MoveUpDarknutSprite) ((MoveUpDarknutSprite)sprite).Draw(spriteBatch, scale, drawColor);
            else if (sprite is MoveDownDarknutSprite) ((MoveDownDarknutSprite)sprite).Draw(spriteBatch, scale, drawColor);
        }
    }
}