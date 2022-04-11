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
        protected const int topBorder = 32, bottomBorder = 143, leftBorder = 32, rightBorder = 223;
        protected const int hurtCooldownLimit = 30;
        protected bool isCollisionWithLink = false;
        protected readonly List<Color> damagedColors = new List<Color>() { Color.Red, Color.Green, Color.Yellow };
        protected Color drawColor = Color.White;
        protected Texture2D spriteSheet;
        protected Vector2 pos = new Vector2(400, 400);
        protected readonly List<Rectangle> animationFrames = new List<Rectangle>();
        protected int currentFrame = 0, hurtCooldown = 0;
        public virtual Vector2 position { get { return pos; } set { pos = value; } }
        public virtual Texture2D Texture { get; set; }
        public virtual int Health { get; set; }

        public virtual bool IsCollisionWithLink { get { return isCollisionWithLink; } set { isCollisionWithLink = value; } }
        protected virtual int Rows { get; set; }
        protected virtual int Columns { get; set; }
        protected virtual int CurrentFrame { get; set; }
        protected virtual int TotalFrames { get; set; }
        protected virtual float MoveSpeed { get; set; }
        
        public virtual void Attack() { }
        public virtual void HandleBlockCollision(IGameObject block, ICollision side, int scale)
        {
            if (side is ICollision.SideTop)
            {
                position = new Vector2(position.X, position.Y - MoveSpeed * scale);
            }
            else if (side is ICollision.SideBottom)
            {
                position = new Vector2(position.X, position.Y + MoveSpeed * scale);
            }
            else if (side is ICollision.SideLeft)
            {
                position = new Vector2(position.X - MoveSpeed * scale, position.Y);
            }
            else if (side is ICollision.SideRight)
            {
                position = new Vector2(position.X + MoveSpeed * scale, position.Y);
            }
            else if (side is ICollision.SideNone)
            {
                //do nothing
            }
        }
        public virtual void HandleWeaponCollision(IGameObject weapon, ICollision side)
        {
            if (!(side is ICollision.SideNone) && hurtCooldown == 0)
            {
                hurtCooldown = hurtCooldownLimit;
                Health--;
                Debug.WriteLine("Boom! Enemy is damaged!");
            }
        }
        protected Vector2 MovesPastWallsTest(Vector2 screenOffset, Vector2 newPosition, int scale)
        {
            Vector2 returnPos = new Vector2(newPosition.X, newPosition.Y);
            int top = (topBorder + (int)screenOffset.Y) * scale;
            int bottom = (bottomBorder + (int)screenOffset.Y) * scale;
            int left = (leftBorder + (int)screenOffset.X) * scale;
            int right = (rightBorder + (int)screenOffset.X) * scale;

            if (newPosition.X < left)
                returnPos.X = left;
            else if (newPosition.X + animationFrames[currentFrame].Width * scale > right)
                returnPos.X = right - animationFrames[currentFrame].Width * scale;

            if (newPosition.Y < top)
                returnPos.Y = top;
            else if (newPosition.Y + animationFrames[currentFrame].Height * scale > bottom)
                returnPos.Y = bottom - animationFrames[currentFrame].Height * scale;

            return returnPos;
        }
        public virtual void Update(Vector2 linkPosition, int scale, Vector2 screenOffset)
        {
            Update(scale, screenOffset);
        }
        public virtual void Update(int scale, Vector2 screenOffset) 
        {
            if (hurtCooldown > 0)
            {
                hurtCooldown--;
                int index = hurtCooldown % damagedColors.Count;
                drawColor = damagedColors[index];
            }
            else if (hurtCooldown == 0) drawColor = Color.White;
        }
        public virtual Rectangle ObjectBox(int scale)
        {
            return new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width * scale, animationFrames[currentFrame].Height * scale);
        }
        public virtual void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width * scale, animationFrames[currentFrame].Height * scale);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], drawColor);
        }
        public virtual void HandleCollision(ICollision side, int scale) { }
        public virtual void HandleCollision(ICollision side, int scale, Vector2 screenOffset, int CatchByEnemy) { }
    }
}
