﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Cloud
{
    public interface ICloudState
    {
        void MoveUp();
        void MoveDown();
        void MoveRight();
        void MoveLeft();
        void UseItem();
        void Attack();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}