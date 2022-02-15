using LegendOfZelda.Content.Enemy.Explosion.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Explosion.State
{
    class NormalExplosionState : BasicExplosionState
    {
        public NormalExplosionState(IExplosion explosion, Vector2 position, ISprite sprite)
        {
            direction = 0;
            this.explosion = explosion;
            this.position = position;
            this.sprite = new NormalExplosionSprite(LoadExplosion.explosionNormal, position);
        }

    }
}
