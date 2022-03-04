using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room16Sprite : BasicRoomBackground
    {
        public Room16Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(1, 1, 256, 159);
        }
        public override void Update() { }
    }
}
