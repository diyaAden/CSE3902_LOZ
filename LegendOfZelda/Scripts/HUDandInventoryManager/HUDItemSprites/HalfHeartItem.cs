using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{

    public class HalfHeartItem : BasicHUDItem
    {
        private readonly int xPos = 121, yPos = 117, width = 8, height = 8;

        public HalfHeartItem(Texture2D HUDText)
        {
            SpriteSheet = HUDText;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }
        public override void Update() { }
    }
}
