using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room11Sprite : BasicRoomBackground
    {
        public Room11Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(772, 355, 256, 176);
        }
        public override void Update() { }
    }
}
