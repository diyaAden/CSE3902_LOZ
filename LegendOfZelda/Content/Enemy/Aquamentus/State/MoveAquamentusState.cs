using LegendOfZelda.Content.Enemy.Aquamentus.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Aquamentus.State
{
    class MoveAquamentusState : BasicAquamentusState
    {
        public MoveAquamentusState(IAquamentus aquamentus, Vector2 position, ISprite sprite)
        {
            direction = 0;
            this.aquamentus = aquamentus;
            this.position = position;
            this.sprite = new MoveAquamentusSprite(LoadAquamentus.aquamentusMove, position);
        }

    }
}
