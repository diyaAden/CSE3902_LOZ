﻿using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    class RightAttackLinkState : BasicLinkState
    {
        public RightAttackLinkState(ILink link, Vector2 position, ISprite sprite, bool isDamaged)
        {
            direction = 3;
            this.link = link;
            this.position = position;
            this.isDamaged = isDamaged;
            this.sprite = new RightAttackLinkSprite(LoadLink.linkRightAttack, position, isDamaged);
        }

    }
}
