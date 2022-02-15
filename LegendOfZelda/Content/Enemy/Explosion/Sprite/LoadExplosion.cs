using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Explosion.Sprite
{
    public static class LoadExplosion
    {
        public static Texture2D explosionNormal;
        
       
        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            explosionNormal = content.Load<Texture2D>("SpriteSheets/Enemy/Explosion");


        }
    }
}
