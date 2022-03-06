using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LegendOfZelda.Scripts.Enemy
{
    public abstract class Enemy : IEnemy
    {
        protected Texture2D spriteSheet;
        protected Rectangle sourceRect;
        protected Vector2 pos = new Vector2(400, 400);
        public virtual Vector2 position { get { return pos; } set { pos = value; } }

        public virtual Texture2D Texture { get; set; }

        protected virtual int Rows { get; set; }
        protected virtual int Columns { get; set; }
        protected virtual int CurrentFrame { get; set; }
        protected virtual int TotalFrames { get; set; }
        protected virtual float MoveSpeed { get; set; }

        public virtual void Attack() { }
        public void HandleBlockCollision(IGameObject block, ICollision side)
        {
            if (side is ICollision.SideTop)
            {
                position = new Vector2(position.X, position.Y - MoveSpeed);
            }
            else if (side is ICollision.SideBottom)
            {
                position = new Vector2(position.X, position.Y + MoveSpeed);
            }
            else if (side is ICollision.SideLeft)
            {
                position = new Vector2(position.X - MoveSpeed, position.Y);
            }
            else if (side is ICollision.SideRight)
            {
                position = new Vector2(position.X + MoveSpeed, position.Y);
            }
            else if (side is ICollision.SideNone)
            {
                //do nothing
            }
        }
            public void HandleWeaponCollision(IGameObject weapon, ICollision side)
        {
            if (!(side is ICollision.SideNone))
            {
                Debug.WriteLine("Boom! Enemy is damaged!");
            }
        }

        public abstract void Update();

        public abstract Rectangle ObjectBox();
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            /*
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            */

        }
    }
}
