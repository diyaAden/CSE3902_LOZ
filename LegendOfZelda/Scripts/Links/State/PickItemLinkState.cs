﻿using LegendOfZelda.Scripts.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.State
{
    class PickItemLinkState : BasicLinkState
    {
        public PickItemLinkState(ILink link, Vector2 position, bool isDamaged)
        {
            direction = 1;
            this.Link = link;
            this.Position = position;
            this.isDamaged = isDamaged;
            this.Sprite = new PickItemLinkSprite(LoadLink.linkPickItem, position, isDamaged);
        }

        public override void PickItem()
        {
            //do nothing

        }

    }
}
