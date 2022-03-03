using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room8Sprite : BasicRoomBackground
    {
        public Room8Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(001, 355, 256, 176);
        }
        public override void Update() { }
    }
}
