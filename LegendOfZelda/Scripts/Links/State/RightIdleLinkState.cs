using LegendOfZelda.Scripts.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.State
{
    class RightIdleLinkState : BasicLinkState
    {
        public RightIdleLinkState(ILink link, Vector2 position, bool isDamaged)
        {
            this.Link = link;
            this.Position = position;
            this.isDamaged = isDamaged;
            this.Sprite = new RightIdleLinkSprite(LoadLink.linkRightMove, position, isDamaged);
        }

    }
}
