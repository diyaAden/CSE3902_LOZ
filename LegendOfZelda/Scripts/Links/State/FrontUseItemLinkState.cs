using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.State
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
