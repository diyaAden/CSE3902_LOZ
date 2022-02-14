using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Content.Items.WeaponSprites;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Content.Items
{
    public class WeaponSpriteFactory
    {
        private Texture2D itemSpriteSheet;
        private Texture2D fireSpriteSheet;
        private Texture2D arrowSwordSpriteSheet;
        private Texture2D smokeCloud;
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
            arrowSwordSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/ArrowSwordSpriteSheet");
            smokeCloud = content.Load<Texture2D>("SpreteSheets/Items/WeaponParticlesSpreteSheet");
        }
        public IItem CreateWoodBoomerangWeaponSprite()
        {
            return new WoodBoomerangWeaponSprite(itemSpriteSheet);
        }
        public IItem CreateMagicBoomerangWeaponSprite()
        {
            return new MagicBoomerangWeaponSprite(itemSpriteSheet);
        }
        public IItem CreateArrowUpWeaponSprite()
        {
            return new ArrowWeaponSprite(arrowSwordSpriteSheet, new Rectangle(52, 0, 5, 16), ArrowWeaponSprite.Direction.Up);
        }
        public IItem CreateMagicArrowUpWeaponSprite()
        {
            return new MagicArrowUpWeaponSprite(arrowSwordSpriteSheet);
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
