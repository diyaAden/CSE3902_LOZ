using System.Collections.Generic;
using LegendOfZelda.Content.Blocks;
using LegendOfZelda.Content.Controller;
using LegendOfZelda.Content.Enemy.Stalfos;
using LegendOfZelda.Content.Enemy.Stalfos.Sprite;
using LegendOfZelda.Content.Enemy.Keese;
using LegendOfZelda.Content.Enemy.Keese.Sprite;
using LegendOfZelda.Content.Enemy.Aquamentus.Sprite;
using LegendOfZelda.Content.Enemy.Aquamentus;
using LegendOfZelda.Content.Enemy.Cloud;
using LegendOfZelda.Content.Enemy.Cloud.Sprite;
using LegendOfZelda.Content.Input.Command;
using LegendOfZelda.Content.Input.Command.Commands;
using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Links;
using LegendOfZelda.Content.Links.Sprite;
using LegendOfZelda.Content.Enemy.Trap;
using LegendOfZelda.Content.Enemy.Trap.Sprite;
using LegendOfZelda.Content.Enemy.Explosion.Sprite;
using LegendOfZelda.Content.Enemy.Explosion;
using LegendOfZelda.Content.Enemy.Fireball;
using LegendOfZelda.Content.Enemy.Fireball.Sprite;
using LegendOfZelda.Content.Enemy.Gel;
using LegendOfZelda.Content.Enemy.Gel.Sprite;
using LegendOfZelda.Content.Enemy.Goriya;
using LegendOfZelda.Content.Enemy.Goriya.Sprite;
using LegendOfZelda.Content.Enemy.WallMaster;
using LegendOfZelda.Content.Enemy.WallMaster.Sprite;
using LegendOfZelda.Content.Links.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<IController> controllerList;
        public ILink link;

        // ENEMY TESTING

        public IStalfos stalfos;
        public Vector2 position2 = new Vector2(400, 100);

        public IKeese keese;
        public Vector2 position3 = new Vector2(200, 200);

        public ITrap trap;
        public Vector2 position4 = new Vector2(200, 100);

        public IGel gel;
        public Vector2 position5 = new Vector2(300, 200);

        public IAquamentus aquamentus;
        public Vector2 position6 = new Vector2(500, 300);

        public ICloud cloud;
        public Vector2 position7 = new Vector2(100, 100);

        public IExplosion explosion;
        public Vector2 position8 = new Vector2(100, 200);

        public IFireball fireball;
        public Vector2 position9 = new Vector2(50, 50);

        public IGoriya goriya;
        public Vector2 position10 = new Vector2(250, 250);

        public IWallMaster wallMaster;
        public Vector2 position11 = new Vector2(400, 400);

        private BlockCollection blockCollection;
        private ItemCollection itemCollection;
        public Vector2 position = new Vector2(400, 300);
        internal List<WeaponManager> activeWeapons;

        internal BlockCollection BlockCollection { get => blockCollection; set => blockCollection = value; }
        internal ItemCollection ItemCollection { get => itemCollection; set => itemCollection = value; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        private void RegisterCommands(KeyboardController control)
        {
            //Game Controls
            control.RegisterCommand(Keys.Q, new QuitGame(this));
            control.RegisterCommand(Keys.R, new ResetGame(this));
            //KeyboardControls for Link
            control.RegisterCommand(Keys.A, new SetLinkLeft(this));
            control.RegisterCommand(Keys.D, new SetLinkRight(this));
            control.RegisterCommand(Keys.Left, new SetLinkLeft(this));
            control.RegisterCommand(Keys.Right, new SetLinkRight(this));
            control.RegisterCommand(Keys.W, new SetLinkUp(this));
            control.RegisterCommand(Keys.S, new SetLinkDown(this));
            control.RegisterCommand(Keys.Up, new SetLinkUp(this));
            control.RegisterCommand(Keys.Down, new SetLinkDown(this));
            control.RegisterCommand(Keys.X, new UseItem(this));
            control.RegisterCommand(Keys.M, new UseItem(this));
            control.RegisterCommand(Keys.E, new SetLinkDamaged(this));
            control.RegisterCommand(Keys.F, new SetLinkIdle(this));
            control.RegisterCommand(Keys.D1, new UseBomb(this));
            control.RegisterCommand(Keys.NumPad1, new UseBomb(this));
            control.RegisterCommand(Keys.D2, new UseArrow(this));
            control.RegisterCommand(Keys.NumPad2, new UseArrow(this));
            control.RegisterCommand(Keys.D3, new UseMagicArrow(this));
            control.RegisterCommand(Keys.NumPad3, new UseMagicArrow(this));
            control.RegisterCommand(Keys.D4, new UseFire(this));
            control.RegisterCommand(Keys.NumPad4, new UseFire(this));
            control.RegisterCommand(Keys.D5, new UseBoomerang(this));
            control.RegisterCommand(Keys.NumPad5, new UseBoomerang(this));
            control.RegisterCommand(Keys.D6, new UseMagicBoomerang(this));
            control.RegisterCommand(Keys.NumPad6, new UseMagicBoomerang(this));
            //Block and item controls
            control.RegisterCommand(Keys.T, new PreviousBlock(this));
            control.RegisterCommand(Keys.Y, new NextBlock(this));
            control.RegisterCommand(Keys.U, new PreviousItem(this));
            control.RegisterCommand(Keys.I, new NextItem(this));
        }

        protected override void Initialize()
        {
            controllerList = new List<IController>();
            KeyboardController control = new KeyboardController(this);
            RegisterCommands(control);
            controllerList.Add(control);
            activeWeapons = new List<WeaponManager>();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            ItemCollection = new ItemCollection();

            //ENEMY TESTING
            LoadStalfos.LoadTexture(Content);
            stalfos = new Stalfos(this, position2);
            LoadKeese.LoadTexture(Content);
            keese = new Keese(this, position3);
            LoadTrap.LoadTexture(Content);
            trap = new Trap(this, position4);
            LoadGel.LoadTexture(Content);
            gel = new Gel(this, position5);
            LoadAquamentus.LoadTexture(Content);
            aquamentus = new Aquamentus(this, position6);
            LoadCloud.LoadTexture(Content);
            cloud = new Cloud(this, position7);
            LoadExplosion.LoadTexture(Content);
            explosion = new Explosion(this, position8);
            LoadFireball.LoadTexture(Content);
            fireball = new Fireball(this, position9);
            LoadGoriya.LoadTexture(Content);
            goriya = new Goriya(this, position10);
            LoadWallMaster.LoadTexture(Content);
            wallMaster = new WallMaster(this, position11);
            // ENEMY TESTING

            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            BlockCollection = new BlockCollection();
            LoadLink.LoadTexture(Content);
            link = new Link(this, position);
            WeaponSpriteFactory.Instance.LoadAllTextures(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            
            // ENEMY TESTING
            stalfos.Update();
            keese.Update();
            trap.Update();
            gel.Update();
            aquamentus.Update();
            cloud.Update();
            explosion.Update();
            fireball.Update();
            goriya.Update();
            wallMaster.Update();
            // ENEMY TESTING

            foreach (WeaponManager weapon in activeWeapons)
            {
                if (weapon.weaponType != WeaponManager.WeaponType.None)
                {
                    weapon.Update();
                }
            }
            link.Update();
            ItemCollection.Update();
            BlockCollection.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            // ENEMY TESTING
            stalfos.Draw(_spriteBatch);
            keese.Draw(_spriteBatch);
            trap.Draw(_spriteBatch);
            gel.Draw(_spriteBatch);
            aquamentus.Draw(_spriteBatch);
            cloud.Draw(_spriteBatch);
            explosion.Draw(_spriteBatch);
            fireball.Draw(_spriteBatch);
            goriya.Draw(_spriteBatch);
            wallMaster.Draw(_spriteBatch);
            // ENEMY TESTING


            BlockCollection.Draw(_spriteBatch);
            ItemCollection.Draw(_spriteBatch);
            foreach (WeaponManager weapon in activeWeapons)
            {
                if (weapon.weaponType != WeaponManager.WeaponType.None)
                {
                    weapon.Draw(_spriteBatch);
                }
            }
            link.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
