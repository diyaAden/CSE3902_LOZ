using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Cloud.Sprite
{
    public static class LoadCloud
    {
        public static Texture2D cloudNormal;
        
       
        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            cloudNormal = content.Load<Texture2D>("SpriteSheets/Enemy/Cloud");


        }
    }
}
