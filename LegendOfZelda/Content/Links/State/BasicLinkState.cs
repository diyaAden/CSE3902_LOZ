using LegendOfZelda.Content.Links.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.State
{
    public class BasicLinkState: ILinkState
    {
        public virtual ILink link { get; set; }
        public virtual Vector2 position { get; set; }
        public virtual ISprite sprite { get; set; }
        protected int timer = 20;

        public virtual void Update()
        {
            timer--;
            if (timer == 0)
            {
                sprite.Update();
                position = sprite.Position;
                timer = 20; //make sure change that when change timer at the beginning
            }
            
        }

        public virtual void MoveUp()
        {
           
        }

        public virtual void MoveDown()
        {

        }
        public virtual void MoveLeft()
        {
            link.state = new LeftWalkLinkState(link, position, sprite);
        }
        public virtual void MoveRight()
        {
            
            link.state = new RightWalkLinkState(link, position, sprite);
        }
        public virtual void Walk()
        {
            
        }

        public virtual void Attack()
        {
            
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }
    }
}
