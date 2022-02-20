using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    class RightUseItemLinkState : BasicLinkState
    {
        public RightUseItemLinkState(ILink link, Vector2 position, ISprite sprite, bool isDamaged)
        {
            this.link = link;
            this.position = position;
            this.isDamaged = isDamaged;
            this.sprite = new RightUseItemLinkSprite(LoadLink.linkRightItem, position, isDamaged);
        }

    }
}
