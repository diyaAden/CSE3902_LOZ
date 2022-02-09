using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    public class RightIdleLinkState: ILinkState
    {
        Texture2D mario;
        Game1 game;
        private ILink link;
        RightIdleLinkSprite RightIdleLinkSprite;


        public RightIdleLinkState(ILink link, Game1 game, Vector2 position)
        {
            LoadTexture(game.Content);
            this.link = link;
            this.RightIdleLinkSprite = new RightIdleLinkSprite(mario, position);
        }
        

        public void Update()
        {
            RightIdleLinkSprite.Update();
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void Walk()
        {
            
        }

        public void Attack()
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            RightIdleLinkSprite.Draw(spriteBatch);
        }

        public void LoadTexture(ContentManager content)
        {
            mario = content.Load<Texture2D>("SpriteSheets/MarioSheet");
        }

        

        
    }
}
