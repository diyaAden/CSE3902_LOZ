using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room11Sprite : BasicRoomBackground
    {
        private readonly int xPos = 772, yPos = 355, width = 256, height = 176;

        public Room11Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }
        public override void Update() { }
    }
}
