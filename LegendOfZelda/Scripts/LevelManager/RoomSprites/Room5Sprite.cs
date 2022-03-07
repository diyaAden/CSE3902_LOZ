using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room5Sprite : BasicRoomBackground
    {
        public Room5Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(258, 532, 256, 176);
        }
        public override void Update() { }
    }
}
