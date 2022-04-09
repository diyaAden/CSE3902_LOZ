using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.Sprite
{
    class RightAttackLinkSprite: BasicLinkSprite
    {    
        private const int linkWidthInTexture = 15;

        public RightAttackLinkSprite(Texture2D texture, Vector2 Position, bool damageState)
        {
            Rows = 3;
            Columns = 1;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            Texture = texture;
            Pos = Position;
            checkDamageState = damageState;
            Timer = 2;
        }
        public override void Update()
        {
            if (--Timer == 0 && CurrentFrame != TotalFrames - 1)
            {
                ++CurrentFrame;
                Timer = 2;
            }
        }
        public override Rectangle LinkBox(int scale)
        {
            GetBoxSize();
            return new Rectangle((int)Pos.X, (int)Pos.Y, linkWidthInTexture * scale, height * scale);
        }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            GetBoxSize();

            if (checkDamageState == true)
            {
                SpriteColor = Color.Red;
            }
            else
            {
                SpriteColor = Color.White;
            }

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = base.LinkBox(scale);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, SpriteColor);

        }
    }
}

