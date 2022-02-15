using LegendOfZelda.Content.Enemy.Trap.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Trap.State
{
    class IdleTrapState : BasicTrapState
    {
        public IdleTrapState(ITrap trap, Vector2 position, ISprite sprite)
        {
            direction = 0;
            this.trap = trap;
            this.position = position;
            this.sprite = new IdleTrapSprite(LoadTrap.trapIdle, position);
        }

    }
}
