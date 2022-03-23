using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room14Sprite : BasicRoomBackground
    {
        private readonly int xPos = 1029, yPos = 178, width = 256, height = 176;

        public Room14Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }
        public override void Update() { }
    }
}
