using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.Sprite
{
    public static class LoadLink
    {
        public static Texture2D linkLeftMove;
        public static Texture2D linkRightMove;
        //public static Texture2D linkFrontMove;
        //public static Texture2D linkBackMove;
        public static void LoadTexture(ContentManager content)
        {
            linkLeftMove = content.Load<Texture2D>("SpriteSheets/Link/LinkLeftMove");
            linkRightMove = content.Load<Texture2D>("SpriteSheets/Link/LinkRightMove");
        }
    }
}
