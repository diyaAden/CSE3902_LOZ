using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Keese.Sprite
{
    public static class LoadKeese
    {
        public static Texture2D keeseFlap;
        public static Texture2D keeseIdle;
        
       
        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            keeseFlap = content.Load<Texture2D>("SpriteSheets/Enemy/Keese");
            keeseIdle = content.Load<Texture2D>("SpriteSheets/Enemy/Keese");


        }
    }
}
