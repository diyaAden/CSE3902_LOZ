using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room14Sprite : BasicRoomBackground
    {
        public Room14Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(1030, 178, 255, 176);
        }
        public override void Update() { }
    }
}
