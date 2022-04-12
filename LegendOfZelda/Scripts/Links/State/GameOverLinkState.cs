using LegendOfZelda.Scripts.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Scripts.Links.State
{
    class GameOverLinkState : BasicLinkState
    {
        protected readonly List<Rectangle> animationFrames = new List<Rectangle>();
        public GameOverLinkState(ILink link, Vector2 position)
        {
            direction = 0;
            this.Link = link;
            this.Position = position;
            this.Sprite = new GameOverLinkSprite(LoadLink.linkGameOver, position);

        }


        

    }
}
