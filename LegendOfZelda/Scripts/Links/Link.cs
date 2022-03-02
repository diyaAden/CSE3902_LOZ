using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Collision.CollisionType;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links.Sprite;
using LegendOfZelda.Scripts.Links.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static LegendOfZelda.Scripts.Items.WeaponManager;
using static LegendOfZelda.Scripts.Links.ILink;

namespace LegendOfZelda.Scripts.Links
{
    public class Link: ILink
    {
        public ILinkState State{ get {return state; } set { state = value; } }
        private ILinkState state;
        bool isDamaged =false;
        private int attackCooldown, cooldownLimit = 30;

        public Link(Vector2 position)
        {
            this.state = new RightIdleLinkState(this, position, isDamaged);
            attackCooldown = 0;
        }

        //Motions that link will have, and change the state.
        public void ToIdle()
        {
            if (attackCooldown == 0) state.ToIdle();
        }
        public void MoveUp()
        {
            if (attackCooldown == 0) state.MoveUp();
        }
        public void MoveDown()
        {
            if (attackCooldown == 0) state.MoveDown();
        }
        public void MoveRight()
        {
            if (attackCooldown == 0) state.MoveRight();
        }
        public void MoveLeft()
        {
            if (attackCooldown == 0) state.MoveLeft();
        }
        public void UseItem()
        {
            if (attackCooldown == 0)
            {
                attackCooldown = cooldownLimit;
                state.UseItem();
            }
        }
        public void Attack()
        {
            if (attackCooldown == 0)
            {
                attackCooldown = cooldownLimit;
                state.Attack();
            }
        }
        public void HandleBlockCollision(IGameObject block, ICollision side)
        {
            if(side is SideTop)
            {
                state.MoveDown();
            }
            else if (side is SideBottom)
            {
                state.MoveUp();
            }
            else if (side is SideLeft)
            {
                state.MoveRight();
            }
            else if (side is SideRight)
            {
                state.MoveLeft();
            }
            else if(side is SideNone)
            {
                //do nothing
            }
        }

        //Update and draw
        public void Update()
        {
            if (attackCooldown != 0) attackCooldown--;
            state.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }
    }
}
