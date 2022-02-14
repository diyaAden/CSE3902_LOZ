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
        public Vector2 position = new Vector2(400, 200);

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
            control.RegisterCommand(Keys.F, new SetLinkIdle(this));
        }

        protected override void Initialize()
        {
            controllerList = new List<IController>();
            KeyboardController control = new KeyboardController(this);
            RegisterCommands(control);
            controllerList.Add(control);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            itemCollection = new ItemCollection();
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            blockCollection = new BlockCollection();
            LoadLink.LoadTexture(Content);
            link = new Link(this, position);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            link.Update();
            itemCollection.Update();
            blockCollection.Update();

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
            itemCollection.Draw(_spriteBatch);
            link.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
