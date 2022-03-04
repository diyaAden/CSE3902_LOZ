using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room12Sprite : BasicRoomBackground
    {
        public Room12Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(1030, 354, 255, 176);
        }
        public override void Update() { }
    }
}
