using System.Collections.Generic;
using LegendOfZelda.Content.Blocks;
using LegendOfZelda.Content.Controller;
using LegendOfZelda.Content.Input.Command;
using LegendOfZelda.Content.Input.Command.Commands;
using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Links;
using LegendOfZelda.Content.Links.Sprite;
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

            BlockCollection.Draw(_spriteBatch);
            ItemCollection.Draw(_spriteBatch);
            foreach (WeaponManager weapon in activeWeapons)
            {
                weapon.Draw(_spriteBatch);
            }
            link.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
