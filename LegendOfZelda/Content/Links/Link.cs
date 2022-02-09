using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links
{
    class Link: ILink
    {
        ILinkState state;
        public void Update()
        {
            state.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

        
    }
}
