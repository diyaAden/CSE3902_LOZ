using LegendOfZelda.Content.Enemy.Gel.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Gel.State
{
    class MoveGelState : BasicGelState
    {
        public MoveGelState(IGel gel, Vector2 position, ISprite sprite)
        {
            direction = 0;
            this.gel = gel;
            this.position = position;
            this.sprite = new MoveGelSprite(LoadGel.gelMove, position);
        }

    }
}
