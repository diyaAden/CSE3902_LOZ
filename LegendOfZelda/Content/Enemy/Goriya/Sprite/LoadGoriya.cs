using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Goriya.Sprite
{
    public static class LoadGoriya
    {
        public static Texture2D goriyaIdle;
        public static Texture2D goriyaDownward;
        public static Texture2D goriyaUpward;
        public static Texture2D goriyaRight;
        public static Texture2D goriyaLeft;




        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            goriyaIdle = content.Load<Texture2D>("SpriteSheets/Enemy/GoriyaIdle");
            goriyaDownward = content.Load<Texture2D>("SpriteSheets/Enemy/GoriyaDownward");
            goriyaUpward = content.Load<Texture2D>("SpriteSheets/Enemy/GoriyaUpward");
            goriyaLeft = content.Load<Texture2D>("SpriteSheets/Enemy/GoriyaLeft");
            goriyaRight = content.Load<Texture2D>("SpriteSheets/Enemy/GoriyaRight");




        }
    }
}
