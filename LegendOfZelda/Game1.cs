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
using System.Diagnostics;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<IController> controllerList;
        private List<ICollection> objectCollections;

        private List<ICollisionDetector> collisionDetectors;
        private List<ICollisionHandler> collisionHandlers;


        public Vector2 position = new Vector2(20, 40);
        public ILink link;

        public RoomManager roomManager;
        internal List<IWeapon> activeWeapons = new List<IWeapon>();

        internal ICollection EnemyCollection { get; private set; }
        internal ICollection BlockCollection { get; private set; }
        internal ICollection ItemCollection { get; private set; }

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

            roomManager = new RoomManager(); // here for testing

            CollisionPlayerBlockDetector collisionPlayerBlockDetector = new CollisionPlayerBlockDetector();
            CollisionEnemyItemDetector collisionEnemyItemDetector = new CollisionEnemyItemDetector();
            collisionDetectors = new List<ICollisionDetector>() { collisionPlayerBlockDetector, collisionEnemyItemDetector };

            PlayerBlockCollisionHandler playerBlockCollisionHandler = new PlayerBlockCollisionHandler();
            EnemyItemCollisionHandler enemyItemCollisionHandler = new EnemyItemCollisionHandler();
            collisionHandlers = new List<ICollisionHandler>() { playerBlockCollisionHandler, enemyItemCollisionHandler };

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
            ItemCollection = new ItemCollection();
            

            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            EnemyCollection = new EnemyCollection();

            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            BlockCollection = new BlockCollection();

            RoomBackgroundFactory.Instance.LoadAllTextures(Content);

            LoadLink.LoadTexture(Content);
            link = new Link(position);
            
            WeaponSpriteFactory.Instance.LoadAllTextures(Content);
            objectCollections = new List<ICollection>() { BlockCollection, ItemCollection, EnemyCollection };

            roomManager.LoadContent(); // here for testing
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

            //foreach (ICollisionDetector collisionDetector in collisionDetectors)

            ICollisionDetector collisionDetector = collisionDetectors[0];
            //will refactor this part next time...
            ILevel room = roomManager.Rooms[roomManager.CurrentRoom];
            List<IBlock> blocks = room.Blocks;
            List<IEnemy> enemys = room.Enemies;
            foreach (IBlock block in blocks)
            {
                IGameObject gameObject = (IGameObject)block;

                List<ICollision> sides = collisionDetector.BoxTest(link, gameObject);

                foreach (ICollision side in sides)
                {
                    collisionHandlers[0].HandleCollision(link, gameObject, side);
                }
            }
            collisionDetector = collisionDetectors[1];
            foreach (IEnemy enemy in enemys)
            {
                foreach (IWeapon weapon in activeWeapons)
                    
                {
                    if (!weapon.IsNull())
                    {
                        IGameObject gameObject = (IGameObject)weapon;


                        List<ICollision> sides = collisionDetector.BoxTest(enemy, gameObject);

                        foreach (ICollision side in sides)
                        {
                            collisionHandlers[1].HandleCollision(enemy, gameObject, side);

                        }
                    }
                }

            }

           roomManager.Update(); // here for testing

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);

            roomManager.Draw(_spriteBatch); // here for testing

            //foreach (ICollection collection in objectCollections) { collection.Draw(_spriteBatch); }

            foreach (IWeapon weapon in activeWeapons)
            {
                if (weapon.GetWeaponType() != IWeapon.WeaponType.NONE) { weapon.Draw(_spriteBatch); }
            }
            link.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
