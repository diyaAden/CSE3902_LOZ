using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{

    public class BlackSpace : BasicHUDItem
    {
        private readonly int xPos = 45, yPos = 63, width = 8, height = 8;

        public BlackSpace(Texture2D HUDText)
        {
            SpriteSheet = HUDText;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }
        public override void Update() { }
    }
}
