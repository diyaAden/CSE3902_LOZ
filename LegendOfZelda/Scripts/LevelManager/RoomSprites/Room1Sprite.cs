using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room1Sprite : BasicRoomBackground
    {
        public Room1Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(258, 886, 256, 176);
        }
        public override void Update() { }
    }
}
