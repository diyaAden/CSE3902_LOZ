using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    class RightWalkLinkState: BasicLinkState
    {
        public RightWalkLinkState(ILink link, Vector2 position, ISprite sprite)
        {
            direction = 3;
            this.link = link;
            this.position = position;
            this.sprite = new RightWalkLinkSprite(LoadLink.linkRightMove, position, isDamaged);
        }

        public override void MoveRight()
        {
            //do nothing
        }
    }
}
