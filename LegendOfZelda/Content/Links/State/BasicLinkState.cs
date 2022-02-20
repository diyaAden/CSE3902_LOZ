﻿using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    class BasicLinkState : ILinkState
    {
        public virtual ILink link { get; set; }
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

        protected static int direction = 3;
        public int Direction { get { return direction; } }
        protected int timer = 20;
        public bool isDamaged = false;

        

        public virtual void Update()
        {
            
            
            
                sprite.Update();
                position = sprite.Position;
                timer = 20; //make sure change that when change timer at the beginning


        }
        
        public virtual void toDamaged()
        {
            isDamaged = true;
        }
        public virtual void ToIdle()
        {
            if (direction == 0)
            {
                link.state = new FrontIdleLinkState(link, position, sprite);
            }
            else if (direction == 1)
            {
                link.state = new BackIdleLinkState(link, position, sprite);
            }
            else if (direction == 2)
            {
                link.state = new LeftIdleLinkState(link, position, sprite);
            }
            else if (direction == 3)
            {
                link.state = new RightIdleLinkState(link, position, sprite);
            }

        }
        public virtual void MoveUp()
        {
            link.state = new BackWalkLinkState(link, position, sprite);
        }

        public virtual void MoveDown()
        {
            link.state = new FrontWalkLinkState(link, position, sprite);
        }
        public virtual void MoveLeft()
        {
            link.state = new LeftWalkLinkState(link, position, sprite);
            
        }
        public virtual void MoveRight()
        {
            link.state = new RightWalkLinkState(link, position, sprite);
        }

        public virtual void UseItem()
        {
                if (direction == 0)
                {
                    link.state = new FrontUseItemLinkState(link, position, sprite);
                }
                else if (direction == 1)
                {
                    link.state = new BackUseItemLinkState(link, position, sprite);
                }
                else if (direction == 2)
                {
                    link.state = new LeftUseItemLinkState(link, position, sprite);
                }
                else if (direction == 3)
                {
                    link.state = new RightUseItemLinkState(link, position, sprite);
                }
        }

        public virtual void Attack()
        {
            // Must apply the other 3 directions
            if (direction == 0)
            {
                link.state = new FrontAttackLinkState(link, position, sprite);
            }
            else if (direction == 1)
            {
                link.state = new BackAttackLinkState(link, position, sprite);
            }
            else if (direction == 2)
            {
                link.state = new LeftAttackLinkState(link, position, sprite);
            }
            else if (direction == 3)
            {
                link.state = new RightAttackLinkState(link, position, sprite);
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }
    }
}