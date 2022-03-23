using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links.Sprite;
using LegendOfZelda.Scripts.Links.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Links
{
    public class Link: ILink
    {
        public ILinkState State{ get {return state; } set { state = value; } }
        private ILinkState state;
        bool isDamaged =false;
        private int attackCooldown, cooldownLimit = 30;
        private List<Vector2> roomSwapPositions = new List<Vector2>() { new Vector2(122, 32), new Vector2(122, 127), new Vector2(208, 80), new Vector2(34, 80), new Vector2(48, 5), new Vector2(111, 80) };

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

        public void PickItem(String name, int scale)
        {
            if (attackCooldown == 0)
            {
                attackCooldown = cooldownLimit;
                state.PickItem(name, scale);
            }
        }
        public void HandleBlockCollision(IGameObject gameObject, ICollision side)
        {
            if (side is ICollision.SideTop)
            {
                state.PositionDown();
            }
            else if (side is ICollision.SideBottom)
            {
                state.PositionUp();
            }
            else if (side is ICollision.SideLeft)
            {
                state.PositionRight();
            }
            else if (side is ICollision.SideRight)
            {
                state.PositionLeft();
            }
            else if (side is ICollision.SideNone)
            {
                //do nothing
            }
        }
        public void HandleDoorCollision(int direction, int scale)
        {
            state.Position = new Vector2(roomSwapPositions[direction].X * scale, roomSwapPositions[direction].Y * scale);
        }
        public void HandleEnemyCollision(IEnemy enemy, ICollision side)
        {
            if (!(side is ICollision.SideNone))
            {
                Debug.WriteLine("enemy collision registered");
                // isDamaged = true;
               
                state.ToDamaged();
            }

        }

        public void HandleWeaponCollision(IGameObject gameObject, ICollision side)
        {
            if (!(side is ICollision.SideNone))
            {
                Debug.WriteLine("hurt by urs weapon");
                isDamaged = true;
                state.ToDamaged();
            }

        }
        public void HandleItemCollision(IGameObject gameObject, ICollision side, int scale)
        {
            if (!(side is ICollision.SideNone))
            {
                Debug.WriteLine(((IItem)gameObject).Name);
                Debug.WriteLine("Pick up item!!!!");
                PickItem(((IItem)gameObject).Name, scale);

            }
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
