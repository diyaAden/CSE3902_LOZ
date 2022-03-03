using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room9Sprite : BasicRoomBackground
    {
        public Room9Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(258, 355, 256, 176);
        }
        public override void Update() { }
    }
}
