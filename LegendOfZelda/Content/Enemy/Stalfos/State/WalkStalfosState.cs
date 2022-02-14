using LegendOfZelda.Content.Enemy.Stalfos.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Stalfos.State
{
    class WalkStalfosState : BasicStalfosState
    {
        public WalkStalfosState(IStalfos stalfos, Vector2 position, ISprite sprite)
        {
            direction = 0;
            this.stalfos = stalfos;
            this.position = position;
            this.sprite = new WalkStalfosSprite(LoadStalfos.stalfosNormal, position);
        }

    }
}
