﻿using LegendOfZelda.Content.Enemy.Stalfos.Sprite;
using LegendOfZelda.Content.Enemy.Stalfos.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Stalfos
{
    public class Stalfos : IStalfos
    {
        public IStalfosState state{ get; set; }
        private ISprite sprite;

        public Stalfos(Game1 game, Vector2 position)
        {
            this.state = new WalkStalfosState(this, position, sprite);
        }

        //Motions that link will have, and change the state.
        public void MoveUp()
        {
            state.MoveUp();
        }
        public void MoveDown()
        {
            state.MoveDown();
        }
        public void MoveRight()
        {
            state.MoveRight();
        }
        public void MoveLeft()
        {
            state.MoveLeft();
        }
        public void UseItem()
        {
            state.UseItem();
        }
        public void Attack()
        {
            state.Attack();
        }

        //Update and draw
        public void Update()
        {
            state.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        
    }
}
