using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{

    public class EmptyHeartItem : BasicHUDItem
    {
        private readonly int xPos = 112, yPos = 117, width = 8, height = 8;

        public EmptyHeartItem(Texture2D HUDText)
        {
            SpriteSheet = HUDText;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }
        public override void Update() { }
    }
}
