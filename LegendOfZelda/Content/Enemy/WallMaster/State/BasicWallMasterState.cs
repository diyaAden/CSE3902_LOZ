using LegendOfZelda.Content.Enemy.WallMaster.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.WallMaster.State
{
    class BasicWallMasterState : IWallMasterState
    {
        public virtual IWallMaster wallMaster { get; set; }
        public virtual Vector2 position { get; set; }
        public virtual ISprite sprite { get; set; }
        /*
            direction = 0 ->Front
            direction = 1 ->Back
            direction = 2 ->Left
            direction = 3 ->Right

            only move could change direction
            use static to let child change parent data.
        */

        protected static int direction = 2;
        protected int timer = 20;

        public virtual void Update()
        {
            timer--;
            if (timer == 0)
            {
                sprite.Update();
                position = sprite.Position;
                timer = 20; //make sure change that when change timer at the beginning
            }
            
        }
        
       
        public virtual void MoveUp()
        {
            wallMaster.state = new IdleWallMasterState(wallMaster, position, sprite);
        }

        public virtual void MoveDown()
        {
            wallMaster.state = new IdleWallMasterState(wallMaster, position, sprite);
        }
        public virtual void MoveLeft()
        {
            wallMaster.state = new IdleWallMasterState(wallMaster, position, sprite);
        }
        public virtual void MoveRight()
        {
            wallMaster.state = new IdleWallMasterState(wallMaster, position, sprite);
        }

        public virtual void UseItem()
        {
           
            // here if we need him to use item
           
        }

        public virtual void Attack()
        {
            // here if we need him to attack
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }
    }
}
