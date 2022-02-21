using LegendOfZelda.Content.Enemy.Fireball.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Fireball.State
{
    class NormalFireballTrioState : BasicFireballState
    {
        public NormalFireballTrioState(IFireball fireball, Vector2 position, ISprite sprite)
        {
            direction = 0;
            this.fireball = fireball;
            this.position = position;
            this.sprite = new NormalFireballSprite(LoadFireball.fireballNormal, position);
        }

    }
}
