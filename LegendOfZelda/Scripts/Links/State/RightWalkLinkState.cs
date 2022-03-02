using LegendOfZelda.Scripts.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.State
{
    class RightWalkLinkState: BasicLinkState
    {
        public RightWalkLinkState(ILink link, Vector2 position, bool isDamaged)
        {
            direction = 3;
            this.Link = link;
            this.Position = position;
            this.isDamaged = isDamaged;
            this.Sprite = new RightWalkLinkSprite(LoadLink.linkRightMove, position, isDamaged);
        }

        public override void MoveRight()
        {
            Position = new Vector2(Position.X + Sprite.LinkMoveSpeed, Position.Y);
            Sprite.Position = Position;
            //do nothing
        }
    }
}
