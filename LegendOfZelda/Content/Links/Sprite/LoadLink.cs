﻿using Microsoft.Xna.Framework.Content;
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
        public static Texture2D linkFrontMove;
        public static Texture2D linkBackMove;
        public static Texture2D linkLeftItem;
        public static Texture2D linkRightItem;
        public static Texture2D linkFrontItem;
        public static Texture2D linkBackItem;
        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            linkLeftMove = content.Load<Texture2D>("SpriteSheets/Link/LinkLeftMove");
            linkRightMove = content.Load<Texture2D>("SpriteSheets/Link/LinkRightMove");
            linkFrontMove = content.Load<Texture2D>("SpriteSheets/Link/LinkFrontMove");
            linkBackMove = content.Load<Texture2D>("SpriteSheets/Link/LinkBackMove");
            //Use item
            linkLeftItem = content.Load<Texture2D>("SpriteSheets/Link/LeftUseItem");
            linkRightItem = content.Load<Texture2D>("SpriteSheets/Link/RightUseItem");
            linkFrontItem = content.Load<Texture2D>("SpriteSheets/Link/FrontUseItem");
            linkBackItem = content.Load<Texture2D>("SpriteSheets/Link/BackUseItem");
        }
    }
}
