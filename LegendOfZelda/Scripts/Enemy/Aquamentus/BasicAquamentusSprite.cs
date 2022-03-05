using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Enemy.Aquamentus.Sprite
{
    class BasicAquamentusSprite : Enemy
    {

        private int animationTimer = 0, currentFrame = 0;
        private List<Rectangle> animationFrames = new List<Rectangle>();
        protected int moveSpeed = 2;
        private List<IEnemy> fireballs = new List<IEnemy>();


        public BasicAquamentusSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 24, 32));
            animationFrames.Add(new Rectangle(24, 0, 24, 32));
            animationFrames.Add(new Rectangle(48, 0, 24, 32)); 
            animationFrames.Add(new Rectangle(72, 0, 24, 32));
        }

        public override void Attack()
        {
            fireballs = new List<IEnemy>();
            for (int i = -1; i < 2; i++)
            {
                fireballs.Add(EnemySpriteFactory.Instance.CreateFireballSprite(i, pos));
            }
        }

        public override void Update()
        {
            if (++animationTimer % 4 == 0)
            {
                currentFrame = ++currentFrame % animationFrames.Count;
                if (animationTimer == 160)
                {
                    animationTimer = 0;
                    Attack();
                }
            }
            foreach (IEnemy fireball in fireballs)
            {
                fireball.Update();
            }
            var rand = new Random();
            
            position = new Vector2(position.X + (rand.Next(-2, 2)), position.Y - (rand.Next(-2, 2)));

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEnemy fireball in fireballs)
            {
                fireball.Draw(spriteBatch);
            }
            Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }

    }
}

