using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.HUD
{
    public class HUDAppearance : IHUDAppearance
    {
        public Vector2 position { get; set; }

        private static readonly HUDAppearance instance = new HUDAppearance();

        public static HUDAppearance Instance => instance;


        public SpriteFont font;
        private int score = 0;
        public HUDAppearance()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            font = content.Load<SpriteFont>("HUD"); // Use the name of your sprite font file here instead of 'Score'.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "LIFE", new Vector2(5, 5), Color.White);
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
