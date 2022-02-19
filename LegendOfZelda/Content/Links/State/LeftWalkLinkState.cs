using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    class LeftWalkLinkState : BasicLinkState
    {
        public LeftWalkLinkState(ILink link, Vector2 position, ISprite sprite)
        {
            direction = 2;
            this.link = link;
            this.position = position;
            this.sprite = new LeftWalkLinkSprite(LoadLink.linkLeftMove, position, isDamaged);
        }

        public override void MoveLeft()
        {
            //do nothing

        }
    }
}
