using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class BombItemSprite : BasicItem
    {
        private const int xPos = 39, yPos = 0, width = 8, height = 14;
        private const string itemName = "Bomb";

        public BombItemSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(xPos, yPos, width, height));
            name = itemName;
        }

        public override void Update()
        {
            
        }
    }
}
