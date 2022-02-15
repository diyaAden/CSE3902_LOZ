using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Stalfos.Sprite
{
    public static class LoadStalfos
    {
        public static Texture2D stalfosNormal;
        public static Texture2D staflosFlipped;
        
       
        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            stalfosNormal = content.Load<Texture2D>("SpriteSheets/Enemy/Stalfos");
            


        }
    }
}
