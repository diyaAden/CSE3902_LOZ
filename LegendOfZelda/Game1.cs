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
using LegendOfZelda.Scripts.GameStateMachine;
using LegendOfZelda.Scripts.HUDandInventoryManager;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList;

        private readonly Vector2 screenOffset = new Vector2(80, 60);
        private readonly Vector2 linkStartPosition = new Vector2(120, 120);
        internal readonly List<IWeapon> activeWeapons = new List<IWeapon>();
        public readonly int gameScale = 2;
        public DetectorManager detectorManager;
        public HandlerManager handlerManager;
        public ILink link;
        public RoomManager roomManager;

        public KeyboardController endGameControl;
        public HUDInventoryManager HUDManager;

        public GameState Gstate;
        public HUDSprite HUD;
        public RoomMovingController roomMovingController;

        
        //public GameStateManager gameStateManager;


        /*
         * Pause Trial
         */

        Texture2D pausedTexture;
        Rectangle pausedRectangle;

        /*
         * End Pause Trial
         */

        /* 
         * Game Over Trial
         */

        Texture2D gameOverTexture;
        Rectangle gameOverRectangle;

        /*
         * End GameOver Trial
         */

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            KeyboardController control = new KeyboardController();
            endGameControl = new KeyboardController();
            MouseController mouse = new MouseController();
            GamepadController gamepad = new GamepadController();
            InitializeController con = new InitializeController(this);
            con.RegisterCommands(control);
            con.RegisterCommands(mouse);
            con.RegisterCommands(gamepad);
            con.RegisterEndGame(endGameControl);
            controllerList = new List<IController>() { control, mouse };

            GameStateController.Instance.LoadGame(this);
            roomManager = new RoomManager();
            detectorManager = new DetectorManager();
            //handlerManager = new HandlerManager(detectorManager.collisionDetectors);
            HUD = new HUDSprite();
            HUDManager = new HUDInventoryManager(HUD);
            

            //gameStateManager = new GameStateManager();

            base.Initialize();
        }
        public void ResetGame()
        {
            Initialize();
            LoadContent();
            GameStateController.Instance.SetGameStatePlaying();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            HUDSpriteFactory.Instance.LoadAllTextures(Content);
            RoomBackgroundFactory.Instance.LoadAllTextures(Content);
            WeaponSpriteFactory.Instance.LoadAllTextures(Content);
            SoundController.Instance.LoadAllSounds(Content);
            HUDManager.LoadContent();
            HUD.LoadAllTextures(Content);

            roomManager.LoadContent(gameScale, screenOffset);
            roomMovingController = new RoomMovingController(roomManager, gameScale, screenOffset);
            handlerManager = new HandlerManager(detectorManager.collisionDetectors, roomMovingController);

            LoadLink.LoadTexture(Content);
            link = new Link(linkStartPosition, screenOffset, gameScale, HUDManager, handlerManager);

            SoundController.Instance.StartDungeonMusic();



            // ********* GameState **********

            //gameStateManager.LoadContent(gameScale, screenOffset);

            //Paused
            
            pausedTexture = Content.Load<Texture2D>("SpriteSheets/General/PausedScreen");
            pausedRectangle = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);

            //GameOver
            gameOverTexture = Content.Load<Texture2D>("SpriteSheets/General/GameOverScreen");
            gameOverRectangle = new Rectangle(0, 0, gameOverTexture.Width, gameOverTexture.Height);

            //*******************************


        }

        protected override void Update(GameTime gameTime)
        {

            KeyboardState keyboard = Keyboard.GetState();
          //  Gstate = GameState.Paused;

            switch (Gstate)
            {
                case GameState.Playing:
                    handlerManager.room = roomManager.Rooms[roomManager.CurrentRoom];
                    foreach (IController controller in controllerList) { controller.Update(); }

                    for (int i = 0; i < activeWeapons.Count; i++)
                    {
                        while (i < activeWeapons.Count && activeWeapons[i].GetWeaponType() == IWeapon.WeaponType.NONE) { activeWeapons.RemoveAt(i); }
                    }
                    Rectangle linkBox = link.State.LinkBox(gameScale);
                    Vector2 linkCenter = new Vector2(linkBox.X + linkBox.Width / 2f, linkBox.Y + linkBox.Height / 2f);
                    foreach (IWeapon weapon in activeWeapons) { weapon.Update(linkCenter, gameScale); }
                    link.Update();
                    roomManager.Update(link.State.Position, gameScale, screenOffset, link.HasClock);
                    handlerManager.room = roomManager.Rooms[roomManager.CurrentRoom];
                    handlerManager.Update(link, activeWeapons, roomManager, gameScale);

                    //update HUD
                    HUDManager.Update();
                    

                    break;
                case GameState.ItemSelection:

                    break;
                case GameState.Triforce:

                    break;
                case GameState.RoomSwitch:
                    roomMovingController.Update();
                    break;
                case GameState.Paused:
                    
                    if (keyboard.IsKeyDown(Keys.O))
                    {
                        GameStateController.Instance.SetGameStatePlaying();
                    }
                    break;
                case GameState.GameOver:

                    // play animation

                    //reset or exit
                    endGameControl.Update();
                    
                    break;
                case GameState.WonGame:

                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);

            roomManager.Draw(_spriteBatch, gameScale);
            HUD.getItemSprites(link);
            HUD.updateItemCounts(link);
            HUD.Draw(_spriteBatch, gameScale, screenOffset);

            switch (Gstate)
            {
                case GameState.Playing:
                    roomManager.Draw(_spriteBatch, gameScale);
                    foreach (IWeapon w in activeWeapons)
                    {
                        w.Draw(_spriteBatch, gameScale);
                    }
                    link.Draw(_spriteBatch, gameScale);
                    break;
                case GameState.RoomSwitch:
                    roomMovingController.Draw(_spriteBatch);
                    break;
                case GameState.Paused:
                    Rectangle destRect1 = new Rectangle((int)screenOffset.X * gameScale, (int)screenOffset.Y * gameScale, pausedRectangle.Width * gameScale, pausedRectangle.Height * gameScale);
                    _spriteBatch.Draw(pausedTexture, destRect1, pausedRectangle, Color.White);
                    break;
                case GameState.GameOver:
                    link.GameOverLink();
                    Rectangle destRect2 = new Rectangle((int)screenOffset.X * gameScale, (int)screenOffset.Y * gameScale, gameOverRectangle.Width * gameScale, gameOverRectangle.Height * gameScale);
                    //_spriteBatch.Draw(gameOverTexture, destRect2, gameOverRectangle, Color.White);
                    break;
            }
            HUD.Draw(_spriteBatch, gameScale, screenOffset);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
