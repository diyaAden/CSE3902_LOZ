using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room12Sprite : BasicRoomBackground
    {
        public Room12Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(1029, 355, 256, 176);
        }
        public override void Update() { }
    }
}
