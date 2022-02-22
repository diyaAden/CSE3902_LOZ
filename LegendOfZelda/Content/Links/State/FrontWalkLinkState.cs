using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    class FrontWalkLinkState : BasicLinkState
    {
        public FrontWalkLinkState(ILink link, Vector2 position, bool isDamaged)
        {
            direction = 0;
            this.Link = link;
            this.Position = position;
            this.isDamaged = isDamaged;
            this.Sprite = new FrontWalkLinkSprite(LoadLink.linkFrontMove, position, isDamaged);
        }

        public override void MoveDown()
        {
            //do nothing
        }

    }
}
