using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room16Sprite : BasicRoomBackground
    {
        public Room16Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(258, 0, 255, 176);
        }
        public override void Update() { }
    }
}
