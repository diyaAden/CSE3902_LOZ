using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LegendOfZelda.Content.Items.WeaponSprites;
using LegendOfZelda.Content.Items.ItemSprites;

namespace LegendOfZelda.Content.Items
{
    public class WeaponSpriteFactory
    {
        private Texture2D itemSpriteSheet;
        private Texture2D NPCSpriteSheet;
        private static WeaponSpriteFactory instance = new WeaponSpriteFactory();

        public static WeaponSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private WeaponSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("SpriteSheets/itemSpriteSheet");
            NPCSpriteSheet = content.Load<Texture2D>("SpriteSheets/NPCSpriteSheet");
        }
        public IItem CreateWoodBoomerangWeaponSprite()
        {
            return new WoodBoomerangWeaponSprite(itemSpriteSheet);
        }
        public IItem CreateMagicBoomerangWeaponSprite()
        {
            return new MagicBoomerangWeaponSprite(itemSpriteSheet);
        }
        public IItem CreateArrowWeaponSprite()
        {
            return new ArrowWeaponSprite(itemSpriteSheet);
        }
        public IItem CreateMagicArrowWeaponSprite()
        {
            return new MagicArrowWeaponSprite(itemSpriteSheet);
        }
        public IItem CreateBombWeaponSprite()
        {
            return new BombWeaponSprite(itemSpriteSheet);
        }
        public IItem CreateFireWeaponSprite()
        {
            return new FireWeaponSprite(NPCSpriteSheet);
        }
    }
}
