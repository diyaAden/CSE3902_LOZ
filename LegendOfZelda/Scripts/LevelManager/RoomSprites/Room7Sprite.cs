using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room7Sprite : BasicRoomBackground
    {
        public Room7Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(772, 532, 256, 176);
        }
        public override void Update() { }
    }
}
