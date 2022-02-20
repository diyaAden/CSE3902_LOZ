﻿using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    class LeftAttackLinkState : BasicLinkState
    {
        public LeftAttackLinkState(ILink link, Vector2 position, ISprite sprite)
        {
            direction = 2;
            this.link = link;
            this.position = position;
            this.sprite = new LeftAttackLinkSprite(LoadLink.linkLeftAttack, position, isDamaged);
        }

    }
}