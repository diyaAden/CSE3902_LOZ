using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room11Sprite : BasicRoomBackground
    {
        public Room11Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(773, 354, 255, 176);
        }
        public override void Update() { }
    }
}
