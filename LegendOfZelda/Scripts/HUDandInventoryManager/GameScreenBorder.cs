﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class GameScreenBorder
    {
        Texture2D blackScreen;
        Rectangle blackBackgroundSource;
        public Vector2 Position { get; set; } = new Vector2(0, 0);

        public GameScreenBorder()
        {
            blackBackgroundSource = new Rectangle(0, 0, 256, 176);
        }

        public void LoadTextures(ContentManager content)
        {
            blackScreen = content.Load<Texture2D>("SpriteSheets/General/blackScreen");
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {
            Rectangle blackBackgroundDestRect1 = new Rectangle((int)(offset.X * scale + Position.X), (int)((offset.Y - blackBackgroundSource.Height) * scale + Position.Y),
                blackBackgroundSource.Width * scale, blackBackgroundSource.Height * scale);
            Rectangle blackBackgroundDestRect2 = new Rectangle((int)(offset.X * scale + Position.X), (int)((offset.Y + blackBackgroundSource.Height) * scale + Position.Y),
                blackBackgroundSource.Width * scale, blackBackgroundSource.Height * scale);
            Rectangle blackBackgroundDestRect3 = new Rectangle((int)((offset.X - blackBackgroundSource.Width) * scale + Position.X), (int)(offset.Y * scale + Position.Y),
                blackBackgroundSource.Width * scale, blackBackgroundSource.Height * scale);
            Rectangle blackBackgroundDestRect4 = new Rectangle((int)((offset.X + blackBackgroundSource.Width) * scale + Position.X), (int)(offset.Y * scale + Position.Y),
                blackBackgroundSource.Width * scale, blackBackgroundSource.Height * scale);
            spriteBatch.Draw(blackScreen, blackBackgroundDestRect1, blackBackgroundSource, Color.White);
            spriteBatch.Draw(blackScreen, blackBackgroundDestRect2, blackBackgroundSource, Color.White);
            spriteBatch.Draw(blackScreen, blackBackgroundDestRect3, blackBackgroundSource, Color.White);
            spriteBatch.Draw(blackScreen, blackBackgroundDestRect4, blackBackgroundSource, Color.White);
        }
    }
}
