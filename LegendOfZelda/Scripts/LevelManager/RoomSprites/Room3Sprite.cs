using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room3Sprite : BasicRoomBackground
    {
        public Room3Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(772, 886, 256, 176);
        }
        public override void Update() { }
    }
}
