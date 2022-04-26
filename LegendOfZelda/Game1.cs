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
using LegendOfZelda.Scripts;
using System.Diagnostics;
using LegendOfZelda.Scripts.Achievement;
using LegendOfZelda.Scripts.PlayerStats;
using System.Text.Json;
using System.IO;
using System;
using LegendOfZelda.Scripts.HUDandInventoryManager.HUDItemSprites;

namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont spriteFont;
        private List<IController> controllerList;
        private PlayerStat pstat;
        private const string PATH = "stats.json";
        
        private int currentTime = 0, endGameTimer = 0;
        private readonly Vector2 screenOffset = new Vector2(80, 60);
        private readonly Vector2 linkStartPosition = new Vector2(120, 120);
        internal readonly List<IWeapon> activeWeapons = new List<IWeapon>();
        public readonly int gameScale = 2, endGameTimeLimit = 300;
        public DetectorManager detectorManager;
        public HandlerManager handlerManager;
        public ILink link;
        public RoomManager roomManager;

        public EndGameController endGameControl;
        public HealthManager HUDManager;

        public GameState Gstate;
        public ItemSelection HUD;
        public RoomMovingController roomMovingController;

        //HUD testing
        public InventorySprite invSpr;

        public PlayTimer playTimer;

        Texture2D startTexture;
        Rectangle startRectangle;

        Texture2D pausedTexture;
        Rectangle pausedRectangle;
       

        Texture2D gameOverTexture;
        Rectangle gameOverRectangle;

        Texture2D wonGameTexture;
        Rectangle wonGameRectangle;

        //Achievement
        public AchievementCollection achievementCollection;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            KeyboardController control = new KeyboardController();
            endGameControl = new EndGameController();
            MouseController mouse = new MouseController();
            GamepadController gamepad = new GamepadController();
            ComboController comboController = new ComboController();
            InitializeController con = new InitializeController(this);
            con.RegisterCommands(control);
            con.RegisterCommands(mouse);
            con.RegisterCommands(gamepad);
            con.RegisterEndGame(endGameControl);
            con.RegisterCommands(comboController);
            controllerList = new List<IController>() { control, mouse, comboController };

            GameStateController.Instance.LoadGame(this);
            roomManager = new RoomManager();
            detectorManager = new DetectorManager();
           
            HUD = new ItemSelection(gameScale, screenOffset, 1);
            HUDManager = new HealthManager(HUD.HUD);
            invSpr =  new InventorySprite();
            Gstate = GameState.Start;
            achievementCollection = new AchievementCollection();
            //gameStateManager = new GameStateManager();
            playTimer = new PlayTimer();


            base.Initialize();
        }
        public void ResetGame()
        {
            Save(pstat);
            Initialize();
            LoadContent();
            GameStateController.Instance.SetGameStateStart();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("Fonts/basicFont");
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            HUDSpriteFactory.Instance.LoadAllTextures(Content);
            RoomBackgroundFactory.Instance.LoadAllTextures(Content);
            WeaponSpriteFactory.Instance.LoadAllTextures(Content);
            SoundController.Instance.LoadAllSounds(Content);
            HUDManager.LoadContent();
            HUD.LoadAllTextures(Content);
            invSpr.LoadAllTextures(Content); //REMOVE LATER
            currentTime = 0;
            Save(pstat);
            if (pstat is null)
            {
                pstat = new PlayerStat()
                {
                    TimeToBeat = 650,
                    BestTime = "N/A"

                };
                Save(pstat);
            }
            pstat = Load();


            achievementCollection.LoadAllTextures(Content);
            roomManager.LoadContent(gameScale, screenOffset);
            roomMovingController = new RoomMovingController(roomManager, gameScale, screenOffset);
            handlerManager = new HandlerManager(detectorManager.collisionDetectors, roomMovingController, achievementCollection);

            LoadLink.LoadTexture(Content);
            link = new Link(linkStartPosition, screenOffset, gameScale, HUDManager, handlerManager);

            SoundController.Instance.StartDungeonMusic();
            


            // ********* GameState **********

            //gameStateManager.LoadContent(gameScale, screenOffset);

            //Start
           startTexture = Content.Load<Texture2D>("SpriteSheets/General/TitleScreen");
            startRectangle = new Rectangle(0, 0, startTexture.Width, startTexture.Height);
            //Paused

            pausedTexture = Content.Load<Texture2D>("SpriteSheets/General/PausedScreen");
            pausedRectangle = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);

            //GameOver
            gameOverTexture = Content.Load<Texture2D>("SpriteSheets/General/GameOverScreen");
            gameOverRectangle = new Rectangle(0, 0, gameOverTexture.Width, gameOverTexture.Height);

            //WonGame
            wonGameTexture = Content.Load<Texture2D>("SpriteSheets/General/winner");
            wonGameRectangle = new Rectangle(0, 0, gameOverTexture.Width, gameOverTexture.Height);

            //*******************************


        }

        protected override void Update(GameTime gameTime)
        {

            KeyboardState keyboard = Keyboard.GetState();
            //Gstate = GameState.Paused;
            HUD.Update(gameScale, screenOffset, roomManager.CurrentRoom, keyboard);
            HUDManager.Update();
            switch (Gstate)
            {
                case GameState.Start:
                    if (keyboard.IsKeyDown(Keys.Space))
                    {
                        GameStateController.Instance.SetGameStatePlaying();
                    }
                    break;
                case GameState.Playing:
                    endGameTimer = endGameTimeLimit;
                    if (HUDManager.hearts == 0)
                    {
                        GameStateController.Instance.SetGameStateGameOver();
                    }
                    /*
                    if (HUDManager.hasTriforce())
                    {
                        GameStateController.Instance.SetGameStateWonGame();
                    }
                    */
                    currentTime++;
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
                    handlerManager.Update(link, activeWeapons, roomManager, gameScale, screenOffset);

                    //update HUD
                    HUD.GetItemSprites(link);
                    //HUDManager.Update();
                    Debug.WriteLine(roomManager.CurrentRoom);

                    break;
                case GameState.ItemSelection:
                    if (keyboard.IsKeyDown(Keys.Enter))
                    {
                        GameStateController.Instance.SetGameStatePausing();
                    }
                    break;
                case GameState.Triforce:

                    break;
                case GameState.RoomSwitch:
                    roomMovingController.Update();
                    break;
                case GameState.Pausing:

                    break;
                case GameState.GameOver:
                    // play animation
                    achievementCollection.changeCurrentAchievement(0);
                    Save(pstat);
                    link.Update();
                    endGameControl.Update();
                    if (--endGameTimer == 0) ResetGame();
                    //update HUD

                    break;
                case GameState.WonGame:
                    achievementCollection.changeCurrentAchievement(6);
                    if (pstat.BestTime.Equals("N/A")){
                        pstat.BestTime = (currentTime / 60).ToString();
                    }
                    else
                    {
                        if((currentTime / 60) < Int32.Parse(pstat.BestTime))
                        {
                           pstat.BestTime = (currentTime / 60).ToString();

                        }
                    }

                    if(currentTime/60 <= 200)
                    {
                        achievementCollection.changeCurrentAchievement(7);
                    }
                    Save(pstat);
                    endGameControl.Update();
                    if (--endGameTimer == 0) ResetGame();

                    break;
            }


            achievementCollection.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);

           
            
            HUD.updateItemCounts(link);
            HUD.Draw(_spriteBatch, gameScale, screenOffset);

            

            switch (Gstate)
            {
                case GameState.Start:
                    Rectangle destRect4 = new Rectangle(10, 0, gameOverRectangle.Width * 3 , gameOverRectangle.Height * 3);
                    _spriteBatch.Draw(startTexture, destRect4, startRectangle, Color.White);
                    break;
                case GameState.Playing:
                    playTimer.Draw(_spriteBatch, spriteFont, currentTime, pstat);
                    roomManager.Draw(_spriteBatch, gameScale);
                    foreach (IWeapon w in activeWeapons)
                    {
                        w.Draw(_spriteBatch, gameScale);
                    }
                    link.Draw(_spriteBatch, gameScale);
                    HUDManager.Draw(_spriteBatch, gameScale, screenOffset);
                    break;
                case GameState.RoomSwitch:
                    roomMovingController.Draw(_spriteBatch);
                    HUD.Draw(_spriteBatch, gameScale, screenOffset);
                    break;
                case GameState.Pausing:
                    roomManager.Draw(_spriteBatch, gameScale);
                    HUD.Draw(_spriteBatch, gameScale, screenOffset);
                    break;
                case GameState.ItemSelection:
                    break;
                case GameState.WonGame:

                    //draw winner
                    Rectangle destRect3 = new Rectangle((int)screenOffset.X * gameScale, (int)screenOffset.Y * gameScale, gameOverRectangle.Width * gameScale, gameOverRectangle.Height * gameScale);
                    _spriteBatch.Draw(wonGameTexture, destRect3, wonGameRectangle, Color.White);
                    break;
                case GameState.GameOver:
                    link.Draw(_spriteBatch, gameScale);
                    Rectangle destRect2 = new Rectangle((int)screenOffset.X * gameScale, (int)screenOffset.Y * gameScale, gameOverRectangle.Width * gameScale, gameOverRectangle.Height * gameScale);
                    _spriteBatch.Draw(gameOverTexture, destRect2, gameOverRectangle, Color.White);
                    break;
            }
            achievementCollection.Draw(_spriteBatch, gameScale);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        private void Save(PlayerStat stat)
        {
            string serializedText = JsonSerializer.Serialize<PlayerStat>(stat);
            Trace.WriteLine(serializedText);
            File.WriteAllText(PATH, serializedText);
        }

        private PlayerStat Load()
        {
            var fileContent = File.ReadAllText(PATH);
            return JsonSerializer.Deserialize<PlayerStat>(fileContent);
        }
    }
}
