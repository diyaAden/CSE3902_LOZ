using System.Collections.Generic;
using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Content.Controller;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using LegendOfZelda.Scripts.Links.Sprite;
using LegendOfZelda.Scripts.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<IController> controllerList;
        private List<ICollection> objectCollections;

        public Vector2 position = new Vector2(400, 300);
        public ILink link;
        

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
            InitializeController con = new InitializeController(this);
            con.RegisterCommands(control);
            controllerList = new List<IController>() { control };
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

            LoadLink.LoadTexture(Content);
            link = new Link(position);
            
            WeaponSpriteFactory.Instance.LoadAllTextures(Content);
            objectCollections = new List<ICollection>() { BlockCollection, ItemCollection, EnemyCollection };
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
            foreach (ICollection collection in objectCollections) { collection.Update(); }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            
            foreach (ICollection collection in objectCollections) { collection.Draw(_spriteBatch); }

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
