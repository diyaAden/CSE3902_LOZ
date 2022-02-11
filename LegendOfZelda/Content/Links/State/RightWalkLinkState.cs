using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    public class RightWalkLinkState: ILinkState
    {
        Texture2D linkRightMove;
        ILink link;
        Game1 game;
        Vector2 position;
        ISprite sprite;
        int timer = 20;



        public RightWalkLinkState(ILink link, Game1 game, Vector2 position, ISprite sprite)
        {
            LoadTexture(game.Content);
            this.game = game;
            this.link = link;
            this.position = position;
            this.sprite = new RightWalkLinkSprite(linkRightMove, position);
        }
        

        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                sprite.Update();
                position = sprite.Position;
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
            link.state = new LeftWalkLinkState(link, game, position, sprite);
        }
        public void MoveRight()
        {
            //Do nothing
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
            linkRightMove = content.Load<Texture2D>("SpriteSheets/Link/LinkRightMove");
        }

        

        
    }
}
