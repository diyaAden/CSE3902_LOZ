using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room0Sprite : BasicRoomBackground
    {
        public Room0Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(1, 886, 256, 176);
        }
        public override void Update() { }
    }
}
