using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Content.Enemy.Fireball.State;


namespace LegendOfZelda.Content.Enemy.Fireball
{
    
        public interface IFireballTrio
        {
            IFireballTrioState state { get; set; }

            void Update();
            void Draw(SpriteBatch spriteBatch);
        }
    
}
