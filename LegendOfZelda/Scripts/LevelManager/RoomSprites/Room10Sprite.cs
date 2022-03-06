using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room10Sprite : BasicRoomBackground
    {
        public Room10Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(515, 355, 256, 176);
        }
        public override void Update() { }
    }
}
