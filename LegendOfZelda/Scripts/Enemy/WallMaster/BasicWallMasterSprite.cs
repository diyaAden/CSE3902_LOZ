using LegendOfZelda.Scripts.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Enemy.WallMaster.Sprite
{
    class BasicWallMasterSprite : Enemy
    {

        private int animationTimer = 0, direction, timeUntilDirectionChange, movementTimer = 0;
        private readonly float moveSpeed = 0.6f;
        private readonly Random rnd = new Random();

        public BasicWallMasterSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(16, 0, 16, 16));
            MoveSpeed = moveSpeed;
            Health = 3; 
        }
        private Vector2 Move(int direction, int scale, Vector2 screenOffset)
        {
            return direction switch
            {
                0 => MovesPastWallsTest(screenOffset, new Vector2(position.X, position.Y + moveSpeed * scale), scale),
                1 => MovesPastWallsTest(screenOffset, new Vector2(position.X, position.Y - moveSpeed * scale), scale),
                2 => MovesPastWallsTest(screenOffset, new Vector2(position.X - moveSpeed * scale, position.Y), scale),
                _ => MovesPastWallsTest(screenOffset, new Vector2(position.X + moveSpeed * scale, position.Y), scale),
            };
        }
        private Vector2 MovesToWallTest(Vector2 screenOffset, Vector2 newPosition, int scale)
        {
            Vector2 returnPos = new Vector2(newPosition.X, newPosition.Y);
            int top = (topBorder + (int)screenOffset.Y) * scale;
            int bottom = (bottomBorder + (int)screenOffset.Y) * scale;
            int left = (leftBorder + (int)screenOffset.X) * scale;
            int right = (rightBorder + (int)screenOffset.X) * scale;

            if (newPosition.X < left -animationFrames[currentFrame].Width * scale)
            {
                //need move the link to the first screen.
                this.isCollisionWithLink = false;
                Debug.WriteLine("left, link jump!");
            }
            else if(newPosition.X > right)
            {
                this.isCollisionWithLink = false;                
                //move the link to the first screen.
                Debug.WriteLine("right, link jump!");
            }
            if (newPosition.Y < top - animationFrames[currentFrame].Height * scale)
            {
                this.isCollisionWithLink = false;
                //need move the link to the first screen.
                Debug.WriteLine("top, link jump!");
            }
            else if (newPosition.Y > bottom)
            {
                this.isCollisionWithLink = false;
                //need move the link to the first screen.
                Debug.WriteLine("bottom, link jump!");
            }
            return returnPos;
        }
        private Vector2 ToWall(int direction, int scale, Vector2 screenOffset)
        {
            return direction switch
            {
                0 => MovesToWallTest(screenOffset, new Vector2(position.X, position.Y + moveSpeed * scale), scale),
                1 => MovesToWallTest(screenOffset, new Vector2(position.X, position.Y - moveSpeed * scale), scale),
                2 => MovesToWallTest(screenOffset, new Vector2(position.X - moveSpeed * scale, position.Y), scale),
                _ => MovesToWallTest(screenOffset, new Vector2(position.X + moveSpeed * scale, position.Y), scale),
            };
        }
        public override void Update(int scale, Vector2 screenOffset)
        {
            position = Move(direction, scale, screenOffset);
            if (++movementTimer >= timeUntilDirectionChange)
            {
                movementTimer = 0;
                direction = rnd.Next(0, 4);
                timeUntilDirectionChange = rnd.Next(60, 121);
            }
            if (++animationTimer > 10)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }

        public void Update(bool isCollisionWithLink, int scale, Vector2 screenOffset) //this bool is just to divide with the other update
        {
            position = ToWall(direction, scale, screenOffset);
        }

        private int getDirection(ICollision side)
        {
            return side switch
            {
                ICollision.SideBottom => 0,
                ICollision.SideTop => 1,
                ICollision.SideRight => 2,
                _ => 3,
            };
        }
        public override void HandleCollision(ICollision side, int scale, Vector2 screenOffset)
        {
            if (side is ICollision.SideNone) {
                //do nothing
            }
            else
            {
                this.isCollisionWithLink = true;
            }
        }
    }
}

