﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.Sprite
{
    public interface ISprite
    {
        Vector2 getPos();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
