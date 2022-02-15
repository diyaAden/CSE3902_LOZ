using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Trap.Sprite
{
    public static class LoadTrap
    {
        public static Texture2D trapIdle;
        
       
        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            trapIdle = content.Load<Texture2D>("SpriteSheets/Enemy/Trap");


        }
    }
}
