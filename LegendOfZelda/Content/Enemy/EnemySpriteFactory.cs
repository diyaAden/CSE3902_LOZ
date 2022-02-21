using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Content.Enemy.Aquamentus.Sprite;
using LegendOfZelda.Content.Enemy.Cloud.Sprite;
using LegendOfZelda.Content.Enemy.Explosion.Sprite;
using LegendOfZelda.Content.Enemy.Fireball.Sprite;
using LegendOfZelda.Content.Enemy.Gel.Sprite;
using LegendOfZelda.Content.Enemy.Goriya.Sprite;
using LegendOfZelda.Content.Enemy.Keese.Sprite;
using LegendOfZelda.Content.Enemy.Stalfos.Sprite;
using LegendOfZelda.Content.Enemy.Trap.Sprite;
using LegendOfZelda.Content.Enemy.WallMaster.Sprite;




namespace LegendOfZelda.Content.Enemy
{
    class EnemySpriteFactory
    {
        private Texture2D aquamentusSpriteSheet, cloudSpriteSheet, explosionSpriteSheet, fireballSpriteSheet, gelSpriteSheet, goriyaSpriteSheet;
        private static EnemySpriteFactory instance = new EnemySpriteFactory();
        public static EnemySpriteFactory Instance => instance;

        private EnemySpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            aquamentusSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/Aquamentus");
            cloudSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/Cloud");
            explosionSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/Explosion");
            fireballSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/Fireball");
            gelSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/Gel");
            goriyaSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/GoriyaDownward");



        }
        public IEnemy CreateAquamentusSprite()
        {
            return new BasicAquamentusSprite(aquamentusSpriteSheet);
        }
        public IEnemy CreateCloudSprite()
        {
            return new BasicCloudSprite(cloudSpriteSheet);
        }
        public IEnemy CreateExplosionSprite()
        {
            return new BasicExplosionSprite(explosionSpriteSheet);
        }
        public IEnemy CreateFireballSprite()
        {
            return new BasicFireballSprite(fireballSpriteSheet);
        }
        public IEnemy CreateGelSprite()
        {
            return new BasicGelSprite(gelSpriteSheet);
        }
        public IEnemy CreateGoriyaSprite()
        {
            return new BasicGoriyaSprite(goriyaSpriteSheet);
        }
        public IEnemy CreateKeeseSprite()
        {
            return new BasicKeeseSprite();
        }
        public IEnemy CreateStalfosSprite()
        {
            return new BasicStalfosSprite();
        }
        public IEnemy CreateTrapSprite()
        {
            return new BasicTrapSprite();
        }
        public IEnemy CreateWallMasterSprite()
        {
            return new BasicWallMasterSprite();
        }
        
    }
}
