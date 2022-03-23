using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room17Sprite : BasicRoomBackground
    {
        private readonly int xPos = 258, yPos = 1, width = 256, height = 176;

        public Room17Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }
        public override void Update() { }
    }
}
