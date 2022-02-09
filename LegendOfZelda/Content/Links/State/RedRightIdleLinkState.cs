using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    public class RedRightIdleLinkState: ILink
    {
        Texture2D mario;
        Game1 game;
        ILink linkState;
        RedRightIdleLinkSprite redRightIdleLinkSprite;
        public RedRightIdleLinkState(ILink linkState, Game1 game, Vector2 position)
        {
            LoadTexture(game.Content);
            this.linkState = linkState;
            this.redRightIdleLinkSprite = new RedRightIdleLinkSprite(mario, position);
            this.game = game;
        }

        public void Update()
        {
            redRightIdleLinkSprite.Update();
            //linkState.Update();
        }

        public void LoadTexture(ContentManager content)
        {
            mario = content.Load<Texture2D>("SpriteSheets/MarioSheet");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            redRightIdleLinkSprite.Draw(spriteBatch);
        }

    }
}
