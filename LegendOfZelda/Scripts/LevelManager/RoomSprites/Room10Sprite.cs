using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room10Sprite : BasicRoomBackground
    {
        public Room10Sprite(Texture2D DungeonMap)
        {
            spriteSheet = DungeonMap;
            sourceRect = new Rectangle(516, 354, 255, 176);
        }
        public override void Update() { }
    }
}
