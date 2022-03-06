using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room4Sprite : BasicRoomBackground
    {
        public Room4Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(515, 709, 256, 176);
        }
        public override void Update() { }
    }
}
