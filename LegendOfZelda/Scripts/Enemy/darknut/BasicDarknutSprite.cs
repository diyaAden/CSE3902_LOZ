using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Collision;

using System.Collections.Generic;
using LegendOfZelda.Scripts.Links;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Enemy
{
    class BasicDarknutSprite : Enemy
    {
        private readonly int moveSpeed = 1;
        private readonly Random rnd = new Random();
       
        private int animationTimer = 0;
        private int moveTimer = 0, moveTimerLimit = 2;
        private IEnemy sprite;
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
           
            Health = 3; //red is 3, blue is 5.
        }
        public override void HandleBlockCollision(IGameObject block, ICollision side, int scale)
        {
            sprite.HandleBlockCollision(block, side, scale);
            pos = sprite.position;
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
         
            }
         
            base.Update(scale, screenOffset);
      
        }
        public override void HandleWeaponCollision(IGameObject weapon, ICollision side)
        {
            if (!(side is ICollision.SideNone) && hurtCooldown == 0)
            {
                hurtCooldown = hurtCooldownLimit;
                Health--;
                
            }
        }
        private void NewDirection(Vector2 linkPos)
        {
          //  Debug.WriteLine("should be moving ");
            getTargetPos(linkPos);
            if (Math.Abs(targetPos.X - pos.X) < 100 || Math.Abs(targetPos.Y - pos.Y) < 100)
            {

                if (targetPos.X < pos.X)
                {
                    Debug.WriteLine("check A");
                    sprite = EnemySpriteFactory.Instance.CreateDarknutLeftSprite(moveSpeed);
                 
                    moveTimer++;

                }

                //if to the right
                else
                {
                    sprite = EnemySpriteFactory.Instance.CreateDarknutRightSprite(moveSpeed);
                 
                    moveTimer++;
                }
                //if above
                if (moveTimer >= 2)
                {
                    if (targetPos.Y < pos.Y)
                    {
                        sprite = EnemySpriteFactory.Instance.CreateDarknutUpSprite(moveSpeed);
                        moveTimer++;

                    }

                    else
                    {
                        sprite = EnemySpriteFactory.Instance.CreateDarknutDownSprite(moveSpeed);
                       

                    }
                }
            }
            else
            {
              //  sprite  = EnemySpriteFactory.Instance.CreateIdleDarknutSprite(moveSpeed);
            }
            sprite.position = pos;
            if (moveTimer >= moveTimerLimit) moveTimer = 0;
        }

        public override Rectangle ObjectBox(int scale) { return sprite.ObjectBox(scale); }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            sprite.Draw(spriteBatch, scale);
            if (sprite is MoveLeftDarknutSprite) ((MoveLeftDarknutSprite)sprite).Draw(spriteBatch, scale, drawColor);
            else if (sprite is MoveRightDarknutSprite) ((MoveRightDarknutSprite)sprite).Draw(spriteBatch, scale, drawColor);
            else if (sprite is MoveUpDarknutSprite) ((MoveUpDarknutSprite)sprite).Draw(spriteBatch, scale, drawColor);
            else if (sprite is MoveDownDarknutSprite) ((MoveDownDarknutSprite)sprite).Draw(spriteBatch, scale, drawColor);
        }
    }
}