using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Scripts.Items.WeaponSprites;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Scripts.Items
{
    public class WeaponSpriteFactory
    {
        private Texture2D itemSpriteSheet, fireSpriteSheet, arrowSwordSpriteSheet, smokeCloudSpriteSheet, swordShardsSpriteSheet;
        private static readonly WeaponSpriteFactory instance = new WeaponSpriteFactory();

        public static WeaponSpriteFactory Instance => instance;
        private WeaponSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/ItemSpriteSheet");
            fireSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/FireSpriteSheet");
            arrowSwordSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/ArrowSwordSpriteSheet");
            smokeCloudSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/WeaponParticlesSpriteSheet");
            swordShardsSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/SwordShardsSpriteSheet");
        }
        public IItem CreateExplosionSprite()
        {
            return new ExplosionSprite(smokeCloudSpriteSheet);
        }
        public IItem CreateArrowNickSprite()
        {
            return new ArrowNickSprite(smokeCloudSpriteSheet);
        }
        public IItem CreateSwordShardWeaponSprite(int row)
        {
            return new SwordShardWeaponSprite(swordShardsSpriteSheet, row);
        }
        public IItem CreateSwordShardSetWeaponSprite(Vector2 position)
        {
            return new ShardSetWeaponSprite(position);
        }
        public IItem CreateWoodBoomerangWeaponSprite(int facing)
        {
            return new WoodBoomerangWeaponSprite(itemSpriteSheet, facing);
        }
        public IItem CreateMagicBoomerangWeaponSprite(int facing)
        {
            return new MagicBoomerangWeaponSprite(itemSpriteSheet, facing);
        }
        public IItem CreateArrowWeaponSprite(int facingDirection)
        {
            return new ArrowWeaponSprite(arrowSwordSpriteSheet, facingDirection);
        }
        public IItem CreateMagicArrowWeaponSprite(int facingDirection)
        {
            return new MagicArrowWeaponSprite(arrowSwordSpriteSheet, facingDirection);
        }
        public IItem CreateBombWeaponSprite()
        {
            return new BombWeaponSprite(itemSpriteSheet);
        }
        public IItem CreateFireWeaponSprite(int facingDirection)
        {
            return new FireWeaponSprite(fireSpriteSheet, facingDirection);
        }
        public IItem CreateSwordBeamWeaponSprite(int facingDirection)
        {
            return new SwordBeamWeaponSprite(arrowSwordSpriteSheet, facingDirection);
        }
        public IItem CreateSwordWeaponSprite(int facingDirection)
        {
            return new SwordWeaponSprite(arrowSwordSpriteSheet, facingDirection);
        }
    }
}
