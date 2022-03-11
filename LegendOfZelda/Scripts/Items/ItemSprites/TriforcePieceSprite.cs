using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class TriforcePieceSprite : BasicItem
    {
        public TriforcePieceSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 10, 10));
            animationFrames.Add(new Rectangle(11, 0, 10, 10));
            animationTimer = 0;
            name = "TriforcePiece";
        }

        public override void Update()
        {
            if (++animationTimer > 7)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}
