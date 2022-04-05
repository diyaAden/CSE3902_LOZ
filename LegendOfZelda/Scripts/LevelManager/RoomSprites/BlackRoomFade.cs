using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class BlackRoomFade : BasicRoomBackground
    {
        private readonly int xPos = 0, yPos = 0, width = 256, height = 176;
        private const float fadeSpeed = 0.01f, fadeTime = 1f;
        public bool FadeToBlack { get; private set; } = true;
        public bool FadeDone { get; private set; } = false;

        public BlackRoomFade(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(xPos, yPos, width, height);
            Reset();
        }
        public override void Update() 
        {
            if (FadeToBlack)
            {
                transparency += fadeSpeed;
                if (transparency >= fadeTime) FadeToBlack = false;
            }
            else { 
                transparency -= fadeSpeed;
                if (transparency <= 0) FadeDone = true;
            }
        }
        public void Reset()
        {
            FadeToBlack = true;
            FadeDone = false;
            transparency = 0f;
        }
    }
}
