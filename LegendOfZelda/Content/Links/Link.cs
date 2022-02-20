using LegendOfZelda.Content.Links.Sprite;
using LegendOfZelda.Content.Links.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static LegendOfZelda.Content.Items.WeaponManager;
using static LegendOfZelda.Content.Links.ILink;

namespace LegendOfZelda.Content.Links
{
    public class Link: ILink
    {
        public ILinkState state{ get; set; }
        private ISprite sprite;
        private int attackCooldown, cooldownLimit = 30;

        public Link(Game1 game, Vector2 position)
        {
            this.state = new RightIdleLinkState(this, position, sprite);
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
