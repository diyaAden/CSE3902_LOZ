using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room13Sprite : BasicRoomBackground
    {
        public Room13Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(515, 178, 256, 176);
        }
        public override void Update() { }
    }
}
