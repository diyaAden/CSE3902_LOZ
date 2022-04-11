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
            ToWallTest(screenOffset, newPosition, scale);
            return returnPos;
        }

        private bool ToWallTest(Vector2 screenOffset, Vector2 newPosition, int scale)
        {
            isCollisionWithLink = true;

            int top = (topBorder + (int)screenOffset.Y) * scale;
            int bottom = (bottomBorder + (int)screenOffset.Y) * scale;
            int left = (leftBorder + (int)screenOffset.X) * scale;
            int right = (rightBorder + (int)screenOffset.X) * scale;

            if (newPosition.X < left - animationFrames[currentFrame].Width * scale)
            {
                isCollisionWithLink = false;
                Debug.WriteLine("left, link jump!");
            }
            if (newPosition.X > right)
            {
                isCollisionWithLink = false;
                Debug.WriteLine("right, link jump!");
            }
            if (newPosition.Y < top - animationFrames[currentFrame].Height * scale)
            {
                isCollisionWithLink = false;
                Debug.WriteLine("top, link jump!");
            }
            if (newPosition.Y > bottom)
            {
                isCollisionWithLink = false;
                Debug.WriteLine("bottom, link jump!");
            }
            return isCollisionWithLink;
        }
        private Vector2 ToWall(int direction, int scale, Vector2 screenOffset)
        {
            return direction switch
            {
                0 => MovesToWallTest(screenOffset, new Vector2(position.X, position.Y + moveSpeed * scale), scale),
                1 => MovesToWallTest(screenOffset, new Vector2(position.X, position.Y - moveSpeed * scale), scale),
                2 => MovesToWallTest(screenOffset, new Vector2(position.X - moveSpeed * scale, position.Y), scale),
                3 => MovesToWallTest(screenOffset, new Vector2(position.X + moveSpeed * scale, position.Y), scale),
                _ => MovesToWallTest(screenOffset, new Vector2(position.X, position.Y), scale)
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
                ICollision.SideLeft => 3,
                _ => -1
            };
        }
        public override void HandleCollision(ICollision side, int scale, Vector2 screenOffset, int CatchByEnemy)
        {
            if (side is ICollision.SideNone)
            {
                if (CatchByEnemy != -1 && ToWallTest(screenOffset, position, scale) == false)
                {
                    isCollisionWithLink = false;
                }
            }
            else
            {
                if (CatchByEnemy != -1 && ToWallTest(screenOffset, position, scale) != false)
                {
                    isCollisionWithLink = true;
                }
            }
        }
    }
}