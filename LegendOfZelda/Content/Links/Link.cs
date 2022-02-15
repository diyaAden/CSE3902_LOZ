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

        private int facingDirection;
        public int Direction
        {
            get
            {
                return facingDirection;
            }
        }

        public Link(Game1 game, Vector2 position)
        {
            this.state = new RightIdleLinkState(this, position, sprite);
            facingDirection = 2;
        }

        //Motions that link will have, and change the state.
        public void MoveUp()
        {
            state.MoveUp();
            facingDirection = 1;
        }
        public void MoveDown()
        {
            state.MoveDown();
            facingDirection = 3;
        }
        public void MoveRight()
        {
            state.MoveRight();
            facingDirection = 2;
        }
        public void MoveLeft()
        {
            state.MoveLeft();
            facingDirection = 4;
        }
        public void UseItem()
        {
            state.UseItem();
        }
        public void Attack()
        {
            state.Attack();
        }

        //Update and draw
        public void Update()
        {
            state.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        
    }
}
