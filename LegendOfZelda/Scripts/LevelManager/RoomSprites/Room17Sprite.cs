using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room17Sprite : BasicRoomBackground
    {
        public Room17Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(515, 0, 255, 176);
        }
        public override void Update() { }
    }
}
