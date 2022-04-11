using LegendOfZelda.Scripts.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.State
{
    class GameOverLinkState : BasicLinkState
    {
        public GameOverLinkState(ILink link, Vector2 position)
        {
            direction = 1;
            this.Link = link;
            this.Position = position;
            this.Sprite = new GameOverLinkSprite(LoadLink.linkGameOver, position);
        }

        public override void GameOverLink()
        {
            Position = new Vector2(Position.X, Position.Y);
            Sprite.Position = Position;
            //do nothing;
        }
    }
}
