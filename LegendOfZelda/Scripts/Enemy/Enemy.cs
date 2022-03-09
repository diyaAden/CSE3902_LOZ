using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Enemy
{
    public abstract class Enemy : IEnemy
    {
        protected Texture2D spriteSheet;
        protected Rectangle sourceRect;
        protected Vector2 pos = new Vector2(400, 400);
        protected readonly List<Rectangle> animationFrames = new List<Rectangle>();
        protected int currentFrame = 0;
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

        public virtual Rectangle ObjectBox(int scale)
        {
            return new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width * scale, animationFrames[currentFrame].Height * scale);
        }
        public virtual void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width * scale, animationFrames[currentFrame].Height * scale);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }
    }
}
