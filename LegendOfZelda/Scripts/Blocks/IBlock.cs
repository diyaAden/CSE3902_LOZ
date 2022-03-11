﻿using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks
{
    public interface IBlock : IGameObject
    {
        public Vector2 position { get; set; }

        public int adjacentRoom { get; set; }

        public void Update();

        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}
