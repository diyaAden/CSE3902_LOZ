﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room15Sprite : BasicRoomBackground
    {
        public Room15Sprite(Texture2D DungeonMap)
        {
            SpriteSheet = DungeonMap;
            sourceRect = new Rectangle(1286, 178, 256, 176);
        }
        public override void Update() { }
    }
}