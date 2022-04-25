using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Enemy
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
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateGelSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateGoriyaSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateKeeseSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateStalfosSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateTrapSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateWallMasterSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateOldManSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateCharizardSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateZapdosSprite());
            enemyCollection.Add(EnemySpriteFactory.Instance.CreateDarknutSprite());
        }

        public void Next()
        {
            currentObject = ++currentObject % enemyCollection.Count;
        }

        public void Previous()
        {
            if (--currentObject < 0) { currentObject = enemyCollection.Count - 1; }
        }

        public void Update(int scale, Vector2 screenOffset)
        {
            enemyCollection[currentObject].Update(scale, screenOffset);
        }

        public IGameObject GameObject()
        {
            //return enemyCollection[currentObject];
            return null;
        }

        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            enemyCollection[currentObject].Draw(spriteBatch, scale);
        }
    }
}
