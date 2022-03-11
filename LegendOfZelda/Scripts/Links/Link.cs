using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links.Sprite;
using LegendOfZelda.Scripts.Links.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Room CurrentRoom { get; set; }

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

        public void PickItem()
        {
            if (attackCooldown == 0)
            {
                attackCooldown = cooldownLimit;
                state.PickItem();
            }
        }
        public void HandleBlockCollision(IGameObject gameObject, ICollision side)
        {

            if (side is ICollision.SideTop)
            {
                state.MoveDown();
            }
            else if (side is ICollision.SideBottom)
            {
                state.MoveUp();
            }
            else if (side is ICollision.SideLeft)
            {
                state.MoveRight();
            }
            else if (side is ICollision.SideRight)
            {
                state.MoveLeft();
            }
            else if (side is ICollision.SideNone)
            {
                //do nothing
            }

        }

        public void HandleEnemyCollision(IEnemy enemy, ICollision side)
        {
            if (!(side is ICollision.SideNone))
            {
                Debug.WriteLine("enemy collision registered");
                isDamaged = true;
                state.ToDamaged();
            }

        }
        public void HandleItemCollision(IGameObject gameObject, ICollision side)
        {
            if (!(side is ICollision.SideNone))
            {
                Debug.WriteLine("Pick up item!!!!");
                PickItem();
                
            }
        }
        public void HandleItemDestroy(int index)
        {
            CurrentRoom.RemoveObject("Item", index);//The index might be temporarily if change the item manager or collision refactory

        }
        //Update and draw
        public void Update()
        {
            if (attackCooldown != 0) attackCooldown--;
            state.Update();
        }
        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            state.Draw(spriteBatch, scale);
        }
    }
}
