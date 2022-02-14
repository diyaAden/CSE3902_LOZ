using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Aquamentus.Sprite
{
    public static class LoadAquamentus
    {
        public static Texture2D aquamentusMove;
        public static Texture2D aquamentusIdle;
        
       
        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            aquamentusMove = content.Load<Texture2D>("SpriteSheets/Enemy/Aquamentus");
            aquamentusIdle = content.Load<Texture2D>("SpriteSheets/Enemy/Aquamentus");


        }
    }
}
