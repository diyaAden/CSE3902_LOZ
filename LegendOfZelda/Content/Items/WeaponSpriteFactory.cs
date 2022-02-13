using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Content.Items.WeaponSprites;

namespace LegendOfZelda.Content.Items
{
    public class WeaponSpriteFactory
    {
        private Texture2D itemSpriteSheet;
        private Texture2D fireSpriteSheet;
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
            itemSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/ItemSpriteSheet");
            fireSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/FireSpriteSheet");
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
            return new FireWeaponSprite(fireSpriteSheet);
        }
    }
}
