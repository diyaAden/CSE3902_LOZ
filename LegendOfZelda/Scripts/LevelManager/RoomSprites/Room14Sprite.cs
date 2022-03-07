using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room14Sprite : BasicRoomBackground
    {
        public Room14Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(1029, 178, 256, 176);
        }
        public override void Update() { }
    }
}
