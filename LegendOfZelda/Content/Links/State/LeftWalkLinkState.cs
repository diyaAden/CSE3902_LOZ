using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    public class LeftWalkLinkState: ILinkState
    {
        Texture2D linkLeftMove;
        ILink link;
        Game1 game;
        Vector2 position;
        ISprite sprite;
        int timer = 20;



        public LeftWalkLinkState(ILink link, Game1 game, Vector2 position, ISprite sprite)
        {
            LoadTexture(game.Content);
            this.game = game;
            this.link = link;
            this.position = position;
            this.sprite = new LeftWalkLinkSprite(linkLeftMove, position);
        }
        

        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                sprite.Update();
                timer = 20; //make sure change that when change timer at the beginning
            }
            
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
            
            link.state = new RightWalkLinkState(link, game, position, sprite);
        }
        public void Walk()
        {
            
        }

        public void Attack()
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        public void LoadTexture(ContentManager content)
        {
            linkLeftMove = content.Load<Texture2D>("SpriteSheets/Link/LinkLeftMove");
        }

        

        
    }
}
