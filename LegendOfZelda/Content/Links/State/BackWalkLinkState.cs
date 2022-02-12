using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    public class BackWalkLinkState : BasicLinkState
    {
        public BackWalkLinkState(ILink link, Vector2 position, ISprite sprite)
        {
            this.link = link;
            this.position = position;
            this.sprite = new BackWalkLinkSprite(LoadLink.linkBackMove, position);
        }

    }
}
