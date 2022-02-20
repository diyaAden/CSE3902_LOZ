using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    class BackAttackLinkState : BasicLinkState
    {
        public BackAttackLinkState(ILink link, Vector2 position, ISprite sprite)
        {
            direction = 1;
            this.link = link;
            this.position = position;
            this.sprite = new BackAttackLinkSprite(LoadLink.linkBackAttack, position, isDamaged);
        }

    }
}
