using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    class FrontUseItemLinkState : BasicLinkState
    {
        public FrontUseItemLinkState(ILink link, Vector2 position, bool isDamaged)
        {
            this.Link = link;
            this.Position = position;
            this.isDamaged = isDamaged;
            this.Sprite = new FrontUseItemLinkSprite(LoadLink.linkFrontItem, position, isDamaged);

           
        }

    }
}
