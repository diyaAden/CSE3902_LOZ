using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items.ItemClasses
{
    public class AbstractItem : IItem
    {
        private Texture2D spriteSheet;
        private List<Rectangle> animationFrames;
        private int currentFrame = 0;
        private int timer = 0;
        private Vector2 location = new Vector2(0, 0);
        public Vector2 position
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        public AbstractItem(Texture2D itemSpriteSheet, List<Rectangle> frames)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames = frames;
        }

        public void Update()
        {
            timer++;
            if (timer > 10)
            {
                currentFrame = ++currentFrame % animationFrames.Count;
                timer = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)location.X, (int)location.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }
    }
}
