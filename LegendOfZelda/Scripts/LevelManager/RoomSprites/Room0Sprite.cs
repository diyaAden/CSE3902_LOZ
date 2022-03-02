using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room0Sprite : BasicRoomBackground
    {
        public Room0Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(1, 192, 192, 112);
        }
        public override void Update() { }
    }
}
