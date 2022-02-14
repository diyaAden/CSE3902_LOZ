using LegendOfZelda.Content.Enemy.Goriya.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Goriya.State
{
    class WalkLeftGoriyaState : BasicGoriyaState
    {
        public WalkLeftGoriyaState(IGoriya goriya, Vector2 position, ISprite sprite)
        {
            direction = 0;
            this.goriya = goriya;
            this.position = position;
            this.sprite = new WalkLeftGoriyaSprite(LoadGoriya.goriyaLeft, position);
        }

    }
}
