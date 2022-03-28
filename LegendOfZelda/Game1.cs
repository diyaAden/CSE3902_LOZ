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
using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Sounds;

namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;
        private readonly Vector2 screenOffset = new Vector2(0, 32);
        private readonly Vector2 linkStartPosition = new Vector2(120, 120);
        internal readonly List<IWeapon> activeWeapons = new List<IWeapon>();
        public readonly int gameScale = 2;
        public DetectorManager detectorManager;
        public HandlerManager handlerManager;
        public ILink link;
        public RoomManager roomManager;

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
            detectorManager = new DetectorManager();
            handlerManager = new HandlerManager(detectorManager.collisionDetectors);

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
            SoundController.Instance.LoadAllSounds(Content);
            roomManager.LoadContent(gameScale, screenOffset);
            LoadLink.LoadTexture(Content);
            link = new Link(linkStartPosition, screenOffset, gameScale);
            SoundController.Instance.StartDungeonMusic();
        }

        protected override void Update(GameTime gameTime)
        {
            handlerManager.room = roomManager.Rooms[roomManager.CurrentRoom];

            foreach (IController controller in controllerList) { controller.Update(); }

            for (int i = 0; i < activeWeapons.Count; i++)
            {
                while (i < activeWeapons.Count && activeWeapons[i].GetWeaponType() == IWeapon.WeaponType.NONE) { activeWeapons.RemoveAt(i); }
            }
            foreach (IWeapon weapon in activeWeapons) { weapon.Update(link.State.Position); }
            link.Update();
            roomManager.Update(link.State.Position, gameScale, screenOffset);
            handlerManager.Update(link, activeWeapons, roomManager, gameScale);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
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
