using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room6Sprite : BasicRoomBackground
    {
        public Room6Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(515, 532, 256, 176);
        }
        public override void Update() { }
    }
}
