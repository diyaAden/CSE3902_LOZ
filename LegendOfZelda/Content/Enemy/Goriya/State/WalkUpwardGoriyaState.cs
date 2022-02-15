using LegendOfZelda.Content.Enemy.Goriya.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Goriya.State
{
    class WalkUpwardGoriyaState : BasicGoriyaState
    {
        public WalkUpwardGoriyaState(IGoriya goriya, Vector2 position, ISprite sprite)
        {
            direction = 2;
            this.goriya = goriya;
            this.position = position;
            this.sprite = new WalkUpGoriyaSprite(LoadGoriya.goriyaUpward, position);
        }

    }
}
