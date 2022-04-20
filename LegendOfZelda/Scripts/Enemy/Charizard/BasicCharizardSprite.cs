using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Enemy
{
    class BasicCharizardSprite : Enemy
    {

        private int animationTimer = 0, movingUp = 1, attackTimer = 0, attackTimerLimit;
        private readonly int animationSpeed = 5;
        private readonly float moveSpeed = 1f;
        private List<IEnemy> fireballs = new List<IEnemy>();
        private readonly Random rnd = new Random();

        public BasicCharizardSprite(Texture2D PokemonSpriteSheet)
        {
            spriteSheet = PokemonSpriteSheet;
            animationFrames.Add(new Rectangle(421, 70, 30, 25));
            animationFrames.Add(new Rectangle(421, 104, 30, 25));
            MoveSpeed = moveSpeed;
            attackTimerLimit = rnd.Next(100, 130);
            Health = 3;
        }
        
        public override void Attack()
        {
            fireballs = new List<IEnemy>();
            SoundController.Instance.PlayBossRoarSound();
            for (int i = -2; i < 3; i++)
            {
                fireballs.Add(EnemySpriteFactory.Instance.CreateFireballSprite(i, -1, pos));
            }
        }
        public override void HandleBlockCollision(IGameObject block, ICollision side, int scale) { }
        public override void Update(int scale, Vector2 screenOffset) { }
        public void Update(List<IEnemy> Enemies, int scale, Vector2 screenOffset)
        {
            fireballs.Clear();
            if (++animationTimer % animationSpeed == 0)
                currentFrame = ++currentFrame % animationFrames.Count;
            if (animationTimer == animationSpeed * 16)
            {
                movingUp *= -1;
                animationTimer = 0;
            }
            if (++attackTimer == attackTimerLimit)
            {
                attackTimer = 0;
                Attack();
                attackTimerLimit = rnd.Next(120, 181);
            }
            foreach (IEnemy fireball in fireballs)
                Enemies.Add(fireball);
            position = new Vector2(position.X, position.Y - (moveSpeed * movingUp * scale));
            base.Update(scale, screenOffset);
        }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            foreach (IEnemy fireball in fireballs)
                fireball.Draw(spriteBatch, scale);
            base.Draw(spriteBatch, scale);
        }
    }
}

