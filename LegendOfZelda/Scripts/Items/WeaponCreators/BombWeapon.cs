using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class BombWeapon : BasicWeapon
    {
        private const int offsetS = 16, offsetN = -14, offsetW = -8, offsetE = 16;

        public BombWeapon(Vector2 linkPosition, int facing, int scale)
        {
            SoundController.Instance.PlayBombSound();
            Weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
            weaponType = WeaponType.BOMB;
            position = facing switch
            {
                0 => new Vector2(linkPosition.X, linkPosition.Y + offsetS * scale),
                1 => new Vector2(linkPosition.X, linkPosition.Y + offsetN * scale),
                2 => new Vector2(linkPosition.X + offsetW * scale, linkPosition.Y),
                _ => new Vector2(linkPosition.X + offsetE * scale, linkPosition.Y),
            };
            Weapon.Position = position;
        }

        public override void Update(Vector2 linkPosition)
        {
            if (Weapon != null)
            {
                Weapon.Update();
                AnimationTimer = Weapon.AnimationTimer;
                if (++itemLifeSpan == Weapon.TimeLimit) { DestructionOverride(); }
            }
        }

        private void DestructionOverride()
        {
            if (weaponType == WeaponType.BOMB)
            {
                position = Weapon.Position;
                Weapon = WeaponSpriteFactory.Instance.CreateExplosionSprite();
                Weapon.Position = position;
                weaponType = WeaponType.EXPLOSION;
                itemLifeSpan = 0;
            }
            else
            {
                Weapon = null;
                weaponType = WeaponType.NONE;
            }
        }

        public override void DestroyWeapon() { }
    }
}
