using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Enemy.Aquamentus.Sprite
{
    class BasicAquamentusSprite : Enemy
    {

        private int animationTimer = 0, movingRight = 1, attackTimer = 0, attackTimerLimit;
        private readonly int animationSpeed = 5;
        private readonly float moveSpeed = 0.5f;
        private List<IEnemy> fireballs = new List<IEnemy>();
        private readonly Random rnd = new Random();


        public BasicAquamentusSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 24, 32));
            animationFrames.Add(new Rectangle(24, 0, 24, 32));
            animationFrames.Add(new Rectangle(48, 0, 24, 32)); 
            animationFrames.Add(new Rectangle(72, 0, 24, 32));
            MoveSpeed = moveSpeed;
            attackTimerLimit = rnd.Next(120, 181);
        }

        public override void Attack()
        {
            fireballs = new List<IEnemy>();
            SoundController.Instance.PlayBossRoarSound();
            for (int i = -1; i < 2; i++)
                fireballs.Add(EnemySpriteFactory.Instance.CreateFireballSprite(i, pos));
        }
        public override void HandleBlockCollision(IGameObject block, ICollision side, int scale) { }
        public override void Update(int scale, Vector2 screenOffset)
        {
            if (++animationTimer % animationSpeed == 0)
                currentFrame = ++currentFrame % animationFrames.Count;
            if (animationTimer == animationSpeed * 16)
            {
                movingRight *= -1;
                animationTimer = 0;
            }
            if (++attackTimer == attackTimerLimit)
            {
                attackTimer = 0;
                Attack();
                attackTimerLimit = rnd.Next(120, 181);
            }
            foreach (IEnemy fireball in fireballs)
                fireball.Update(scale, screenOffset);
            position = new Vector2(position.X - (moveSpeed * movingRight * scale), position.Y);
        }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            foreach (IEnemy fireball in fireballs)
                fireball.Draw(spriteBatch, scale);
            base.Draw(spriteBatch, scale);
        }
    }
}