using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Scripts.Enemy.Aquamentus.Sprite;
using LegendOfZelda.Scripts.Enemy.Fireball.Sprite;
using LegendOfZelda.Scripts.Enemy.Gel.Sprite;
using LegendOfZelda.Scripts.Enemy.Goriya.Sprite;
using LegendOfZelda.Scripts.Enemy.Keese.Sprite;
using LegendOfZelda.Scripts.Enemy.Stalfos.Sprite;
using LegendOfZelda.Scripts.Enemy.Trap.Sprite;
using LegendOfZelda.Scripts.Enemy.WallMaster.Sprite;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Scripts.Enemy
{
    class EnemySpriteFactory
    {
        private Texture2D goriyaDownSpriteSheet, goriyaRightSpriteSheet, goriyaLeftSpriteSheet, goriyaUpSpriteSheet, oldmanSpriteSheet;
        private Texture2D aquamentusSpriteSheet, cloudSpriteSheet, explosionSpriteSheet, fireballSpriteSheet, gelSpriteSheet, keeseSpriteSheet, stalfosSpriteSheet, trapSpriteSheet, wallMasterSpriteSheet;
        private static readonly EnemySpriteFactory instance = new EnemySpriteFactory();
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
            goriyaDownSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/GoriyaDownward");
            goriyaRightSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/GoriyaRight");
            goriyaLeftSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/GoriyaLeft");
            goriyaUpSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/GoriyaUpward");
            keeseSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/Keese");
            stalfosSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/Stalfos");
            trapSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/Trap");
            wallMasterSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/WallMaster");
            oldmanSpriteSheet = content.Load<Texture2D>("SpriteSheets/Enemy/OldMan");
        }
        public IEnemy CreateEnemyFromString(string enemyName)
        {
            return enemyName switch
            {
                "Aquamentus" => CreateAquamentusSprite(),
                "Gel" => CreateGelSprite(),
                "Goriya" => CreateGoriyaSprite(),
                "Keese" => CreateKeeseSprite(),
                "Stalfos" => CreateStalfosSprite(),
                "Trap" => CreateTrapSprite(),
                "WallMaster" => CreateWallMasterSprite(),
                "OldMan" => CreateOldManSprite(),
                _ => null,
            };
        }
        public IEnemy CreateOldManSprite()
        {
            return new BasicOldManSprite(oldmanSpriteSheet);
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
        public IEnemy CreateFireballSprite(int direction, Vector2 position)
        {
            return new BasicFireballSprite(fireballSpriteSheet, direction, position);
        }
        public IEnemy CreateGelSprite()
        {
            return new BasicGelSprite(gelSpriteSheet);
        }
        public IEnemy CreateGoriyaSprite()
        {
            return new BasicGoriyaSprite();
        }
        public IEnemy CreateGoriyaDownSprite(int moveSpeed)
        {
            return new MoveDownGoriyaSprite(goriyaDownSpriteSheet, moveSpeed);
        }
        public IEnemy CreateGoriyaUpSprite(int moveSpeed)
        {
            return new MoveUpGoriyaSprite(goriyaUpSpriteSheet, moveSpeed);
        }
        public IEnemy CreateGoriyaLeftSprite(int moveSpeed)
        {
            return new MoveLeftGoriyaSprite(goriyaLeftSpriteSheet, moveSpeed);
        }
        public IEnemy CreateGoriyaRightSprite(int moveSpeed)
        {
            return new MoveRightGoriyaSprite(goriyaRightSpriteSheet, moveSpeed);
        }
        public IEnemy CreateKeeseSprite()
        {
            return new BasicKeeseSprite(keeseSpriteSheet);
        }
        public IEnemy CreateStalfosSprite()
        {
            return new BasicStalfosSprite(stalfosSpriteSheet);
        }
        public IEnemy CreateTrapSprite()
        {
            return new BasicTrapSprite(trapSpriteSheet);
        }
        public IEnemy CreateWallMasterSprite()
        {
            return new BasicWallMasterSprite(wallMasterSpriteSheet);
        }
    }
}
