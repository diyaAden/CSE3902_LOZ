using LegendOfZelda.Content.Enemy.Keese.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Keese.State
{
    class FlapKeeseState : BasicKeeseState
    {
        public FlapKeeseState(IKeese keese, Vector2 position, ISprite sprite)
        {
            direction = 0;
            this.keese = keese;
            this.position = position;
            this.sprite = new FlapKeeseSprite(LoadKeese.keeseFlap, position);
        }

    }
}
