using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Fireball.Sprite
{
    public static class LoadFireball
    {
        public static Texture2D fireballNormal;
        
       
        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            fireballNormal = content.Load<Texture2D>("SpriteSheets/Enemy/Fireball");


        }
    }
}
