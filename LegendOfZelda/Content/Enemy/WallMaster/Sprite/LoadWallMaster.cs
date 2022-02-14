using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.WallMaster.Sprite
{
    public static class LoadWallMaster
    {
        public static Texture2D wallMasterIdle;
        
       
        public static void LoadTexture(ContentManager content)
        {
            //Walk or idle
            wallMasterIdle = content.Load<Texture2D>("SpriteSheets/Enemy/WallMaster");


        }
    }
}
