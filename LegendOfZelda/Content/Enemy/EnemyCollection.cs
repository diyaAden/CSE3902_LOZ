﻿using LegendOfZelda.Content.Items;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Enemy
{
    class EnemyCollection : ICollection
    {
        private List<IEnemy> enemyCollection = new List<IEnemy>();
        private int currentObject = 0;

        public EnemyCollection()
        {
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateAquamentusSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateCloudSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateExplosionSprite());
            //enemyCollection.Add(EnemySpriteFactory.Instance.CreateFireballSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateGelSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateGoriyaSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateKeeseSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateStalfosSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateTrapSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateWallMasterSprite());
        }

        public void Next()
        {
            currentObject = ++currentObject % enemyCollection.Count;
        }

        public void Previous()
        {
            if (--currentObject < 0) { currentObject = enemyCollection.Count - 1; }
        }

        public void Update()
        {
            enemyCollection[currentObject].Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemyCollection[currentObject].Draw(spriteBatch);
        }
    }
}
