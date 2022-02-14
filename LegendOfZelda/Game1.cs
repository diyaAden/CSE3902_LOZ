using System.Collections.Generic;
using LegendOfZelda.Content.Blocks;
using LegendOfZelda.Content.Controller;
using LegendOfZelda.Content.Enemy.Stalfos;
using LegendOfZelda.Content.Enemy.Stalfos.Sprite;
using LegendOfZelda.Content.Enemy.Keese;
using LegendOfZelda.Content.Enemy.Keese.Sprite;
using LegendOfZelda.Content.Enemy.Aquamentus.Sprite;
using LegendOfZelda.Content.Enemy.Aquamentus;
using LegendOfZelda.Content.Input.Command;
using LegendOfZelda.Content.Input.Command.Commands;
using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Links;
using LegendOfZelda.Content.Links.Sprite;
using LegendOfZelda.Content.Enemy.Trap;
using LegendOfZelda.Content.Enemy.Trap.Sprite;
using LegendOfZelda.Content.Enemy.Gel;
using LegendOfZelda.Content.Enemy.Gel.Sprite;
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
        public Vector2 position = new Vector2(400, 200);

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

        // ENEMY TESTING


        private ItemCollection itemCollection;
        private BlockCollection blockCollection;
        int timer = 0; //this is part of testing and will be removed later

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
        }

        protected override void Initialize()
        {
            controllerList = new List<IController>();
            KeyboardController control = new KeyboardController();
            RegisterCommands(control);
            controllerList.Add(control);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            itemCollection = new ItemCollection();

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
            // ENEMY TESTING

            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            blockCollection = new BlockCollection();
            LoadLink.LoadTexture(Content);
            link = new Link(this, position);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            link.Update();
            itemCollection.Update();
            blockCollection.Update();

            // ENEMY TESTING
            stalfos.Update();
            keese.Update();
            trap.Update();
            gel.Update();
            aquamentus.Update();
            // ENEMY TESTING

            //if statement and timer used for testing, will remove later
            if (++timer > 100)
            {
                blockCollection.PreviousBlock();
                itemCollection.PreviousItem();
                timer = 0;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            blockCollection.Draw(_spriteBatch);

            // ENEMY TESTING
            stalfos.Draw(_spriteBatch);
            keese.Draw(_spriteBatch);
            trap.Draw(_spriteBatch);
            gel.Draw(_spriteBatch);
            aquamentus.Draw(_spriteBatch);
            // ENEMY TESTING

            itemCollection.Draw(_spriteBatch);
            link.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
