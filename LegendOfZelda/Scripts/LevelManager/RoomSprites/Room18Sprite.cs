using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room18Sprite : BasicRoomBackground
    {
        private readonly int xPos = 515, yPos = 1, width = 256, height = 176;

        public Room18Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }
        public override void Update() { }
    }
}
