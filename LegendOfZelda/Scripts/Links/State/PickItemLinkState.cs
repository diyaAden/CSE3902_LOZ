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
    class PickItemLinkState : BasicLinkState
    {
        private IItem item;
        public PickItemLinkState(ILink link, Vector2 position, bool isDamaged)
        {
            direction = 1;
            this.Link = link;
            this.Position = position;
            this.isDamaged = isDamaged;
            this.Sprite = new PickItemLinkSprite(LoadLink.linkPickItem, position, isDamaged);
        }

        public void CreatePickItem(string name, Vector2 linkPosition)
        {
            item = ItemSpriteFactory.Instance.CreateItemFromString(name);
            item.PickItem(linkPosition);
        }

        public override void PickItem(string name)
        {
            //do nothing

        }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            Sprite.Draw(spriteBatch, scale);
            item.Draw(spriteBatch, scale);
        }


    }
}
