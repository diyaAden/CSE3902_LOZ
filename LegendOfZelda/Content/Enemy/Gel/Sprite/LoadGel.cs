using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Gel.Sprite
{
    public static class LoadGel
    {
        public static Texture2D gelMove;
        public static Texture2D gelIdle;
        
       
        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            gelMove = content.Load<Texture2D>("SpriteSheets/Enemy/Gel");
            gelIdle = content.Load<Texture2D>("SpriteSheets/Enemy/Gel");


        }
    }
}
