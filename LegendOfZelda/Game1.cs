using System.Collections.Generic;
using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Input.Controller;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using LegendOfZelda.Scripts.Links.Sprite;
using LegendOfZelda.Scripts.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Collision.CollisionDetector;
using LegendOfZelda.Scripts.Collision.CollisionHandler;
using LegendOfZelda.Scripts.Collision;

namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<IController> controllerList;

        private List<ICollisionDetector> collisionDetectors;
        private List<ICollisionHandler> collisionHandlers;

        public readonly int gameScale = 2;
        public Vector2 position = new Vector2(120, 80);
        public ILink link;

        public RoomManager roomManager;
        internal List<IWeapon> activeWeapons = new List<IWeapon>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            KeyboardController control = new KeyboardController();
            MouseController mouse = new MouseController();
            InitializeController con = new InitializeController(this);
            con.RegisterCommands(control);
            con.RegisterCommands(mouse);
            controllerList = new List<IController>() { control, mouse };

            roomManager = new RoomManager();

            CollisionPlayerGameObjectDetector collisionPlayerBlockDetector = new CollisionPlayerGameObjectDetector();
            CollisionEnemyGameObjectDetector collisionEnemyItemDetector = new CollisionEnemyGameObjectDetector();
            CollisionPlayerEnemyDetector collisionPlayerEnemyDetector = new CollisionPlayerEnemyDetector();
            collisionDetectors = new List<ICollisionDetector>() { collisionPlayerBlockDetector, collisionEnemyItemDetector, collisionPlayerEnemyDetector };

            PlayerGameObjectCollisionHandler playerBlockCollisionHandler = new PlayerGameObjectCollisionHandler();
            EnemyGameObjectCollisionHandler enemyItemCollisionHandler = new EnemyGameObjectCollisionHandler();
            PlayerEnemyCollisionHandler playerEnemyCollisionHandler = new PlayerEnemyCollisionHandler();
            collisionHandlers = new List<ICollisionHandler>() { playerBlockCollisionHandler, enemyItemCollisionHandler, playerEnemyCollisionHandler };

            base.Initialize();
        }
        public void ResetGame()
        {
            //GraphicsDevice.Reset();
            LoadContent();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            RoomBackgroundFactory.Instance.LoadAllTextures(Content);
            WeaponSpriteFactory.Instance.LoadAllTextures(Content);
            roomManager.LoadContent(gameScale);
            LoadLink.LoadTexture(Content);
            link = new Link(position);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList) { controller.Update(); }
            
            for (int i = 0; i < activeWeapons.Count; i++)
            {
                while (i < activeWeapons.Count && activeWeapons[i].GetWeaponType() == IWeapon.WeaponType.NONE) { activeWeapons.RemoveAt(i); }
            }
            foreach (IWeapon weapon in activeWeapons) { weapon.Update(link.State.Position); }
            link.Update();

            ILevel room = roomManager.Rooms[roomManager.CurrentRoom];
            List<IBlock> blocks = room.Blocks;
            List<IEnemy> enemys = room.Enemies;
            List<IItem> items = room.Items;
            
            //foreach (ICollisionDetector collisionDetector in collisionDetectors)

            ICollisionDetector collisionDetector = collisionDetectors[0];
            //will refactor this part next time...
            
            foreach (IBlock block in blocks)
            {
                List<ICollision> sides = collisionDetector.BoxTest(link, block, gameScale);
                foreach (ICollision side in sides)
                {
                    collisionHandlers[0].HandleCollision(link, block, side);
                }
            }
            foreach (IItem item in items)
            {
                List<ICollision> sides = collisionDetector.BoxTest(link, item, gameScale);
                foreach (ICollision side in sides)
                {
                    collisionHandlers[0].HandleCollision(link, item, side);
                }
            }
            collisionDetector = collisionDetectors[1];
            foreach (IEnemy enemy in enemys)
            {
                List<ICollision> sides2 = collisionDetectors[2].BoxTest(link, enemy, gameScale);
                foreach (ICollision side in sides2)
                {
                    collisionHandlers[2].HandleCollision(link, enemy, side);
                }
                foreach (IWeapon weapon in activeWeapons)
                {
                    if (!weapon.IsNull())
                    {
                        List<ICollision> sides = collisionDetector.BoxTest(enemy, weapon, gameScale);
                        foreach (ICollision side in sides)
                        {
                            collisionHandlers[1].HandleCollision(enemy, weapon, side, gameScale);
                        }
                    }
                }
                foreach (IBlock block in blocks)
                {
                    List<ICollision> sides = collisionDetector.BoxTest(enemy, block, gameScale);

                    foreach (ICollision side in sides)
                    {
                        collisionHandlers[1].HandleCollision(enemy, block, side, gameScale);
                    }
                }
            }
            roomManager.Update(gameScale);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
            roomManager.Draw(_spriteBatch, gameScale);
            foreach (IWeapon weapon in activeWeapons)
            {
                weapon.Draw(_spriteBatch, gameScale);
            }
            link.Draw(_spriteBatch, gameScale);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
