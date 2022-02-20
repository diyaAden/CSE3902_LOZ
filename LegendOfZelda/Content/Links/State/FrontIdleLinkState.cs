using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    class FrontIdleLinkState : BasicLinkState
    {
        public FrontIdleLinkState(ILink link, Vector2 position, ISprite sprite, bool isDamaged)
        {
            this.link = link;
            this.position = position;
            this.isDamaged = isDamaged;
            this.sprite = new FrontIdleLinkSprite(LoadLink.linkFrontMove, position, isDamaged);
            
        }

    }
}
