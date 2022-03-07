using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room17Sprite : BasicRoomBackground
    {
        public Room17Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(258, 1, 256, 176);
        }
        public override void Update() { }
    }
}
