using LegendOfZelda.Scripts.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.State
{
    class RightAttackLinkState : BasicLinkState
    {
        public RightAttackLinkState(ILink link, Vector2 position, bool isDamaged)
        {
            direction = 3;
            this.Link = link;
            this.Position = position;
            this.isDamaged = isDamaged;
            this.Sprite = new RightAttackLinkSprite(LoadLink.linkRightAttack, position, isDamaged);
        }

    }
}
