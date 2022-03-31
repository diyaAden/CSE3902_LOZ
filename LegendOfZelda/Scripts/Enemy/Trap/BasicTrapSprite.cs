using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Enemy.Trap.Sprite
{
    class BasicTrapSprite : Enemy
    {
        enum MovingState { READY, ATTACKING, RETREATING }
        enum Direction { UP, DOWN, LEFT, RIGHT, NONE }
        private MovingState currentState = MovingState.READY;
        private Direction direction = Direction.NONE;
        private bool originSet = false;
        private Vector2 originalPosition;
        private readonly Vector2 permittedMoveDist = new Vector2(84, 44);
        private const int attackSpeed = 2, retreatSpeed = 1, triggerThreshold = 12;

        public override Vector2 position {
            get { return pos; }
            set {
                pos = value;
                if (!originSet) {
                    originSet = true;
                    originalPosition = value;
                }
            }
        }
        public BasicTrapSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            MoveSpeed = retreatSpeed;
            health = 3; //Actually no health.
        }
        private Vector2 Advance(int scale)
        {
            return direction switch
            {
                Direction.DOWN => new Vector2(position.X, position.Y + attackSpeed * scale),
                Direction.UP => new Vector2(position.X, position.Y - attackSpeed * scale),
                Direction.LEFT => new Vector2(position.X - attackSpeed * scale, position.Y),
                _ => new Vector2(position.X + attackSpeed * scale, position.Y),
            };
        }
        private Vector2 BackTrack(int scale)
        {
            return direction switch
            {
                Direction.DOWN => new Vector2(position.X, position.Y - retreatSpeed * scale),
                Direction.UP => new Vector2(position.X, position.Y + retreatSpeed * scale),
                Direction.LEFT => new Vector2(position.X + retreatSpeed * scale, position.Y),
                _ => new Vector2(position.X - retreatSpeed * scale, position.Y),
            };
        }
        private void Attack(int scale)
        {
            position = Advance(scale);
            if (Math.Abs(originalPosition.X - pos.X) >= permittedMoveDist.X * scale || Math.Abs(originalPosition.Y - pos.Y) >= permittedMoveDist.Y * scale)
            {
                currentState = MovingState.RETREATING;
            }
        }
        private void Retreat(int scale)
        {
            position = BackTrack(scale);
            if (position.X == originalPosition.X && position.Y == originalPosition.Y)
            {
                currentState = MovingState.READY;
                direction = Direction.NONE;
            }
        }
        public void DetectDirection(Vector2 linkPosition, int scale)
        {
            if (Math.Abs(originalPosition.X - linkPosition.X) < triggerThreshold * scale)
            {
                currentState = MovingState.ATTACKING;
                if (linkPosition.Y > originalPosition.Y) direction = Direction.DOWN;
                else direction = Direction.UP;
            }
            else if (Math.Abs(originalPosition.Y - linkPosition.Y) < triggerThreshold * scale)
            {
                currentState = MovingState.ATTACKING;
                if (linkPosition.X > originalPosition.X) direction = Direction.RIGHT;
                else direction = Direction.LEFT;
            }
        }
        public override void Update(Vector2 linkPosition, int scale, Vector2 screenOffset)
        {
            if (currentState == MovingState.ATTACKING) Attack(scale);
            else if (currentState == MovingState.RETREATING) Retreat(scale);
            else DetectDirection(linkPosition, scale);
        }
    }
}