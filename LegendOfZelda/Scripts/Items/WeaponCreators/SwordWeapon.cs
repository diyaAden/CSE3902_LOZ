using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class SwordWeapon : BasicWeapon
    {
        public SwordWeapon(Vector2 linkPosition, int facing, int scale)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateSwordWeaponSprite(facing);
            weaponType = WeaponType.SWORDBEAM;
            position = facing switch
            {
                0 => new Vector2(linkPosition.X + 3 * scale, linkPosition.Y + 8 * scale),
                1 => new Vector2(linkPosition.X + 2 * scale, linkPosition.Y - 8 * scale),
                2 => new Vector2(linkPosition.X - 8 * scale, linkPosition.Y + 3 * scale),
                _ => new Vector2(linkPosition.X + 8 * scale, linkPosition.Y + 3 * scale),
            };
            Weapon.Position = position;
        }

        public override void Update(Vector2 linkPosition, int scale)
        {
            if (Weapon != null)
            {
                Weapon.Update();
                AnimationTimer = Weapon.AnimationTimer;
                if (++itemLifeSpan == Weapon.TimeLimit) { DestructionOverride(scale); }
            }
        }

        private void DestructionOverride(int scale)
        {
            if (weaponType == WeaponType.SWORDBEAM) DestroyWeapon(scale);
            else
            {
                Weapon = null;
                weaponType = WeaponType.NONE;
            }
        }

        public override void DestroyWeapon(int scale) {
            if (weaponType == WeaponType.SWORDBEAM)
            {
                position = Weapon.Position;
                Weapon = WeaponSpriteFactory.Instance.CreateSwordShardSetWeaponSprite(position);
                weaponType = WeaponType.SWORDSHARDS;
                itemLifeSpan = 0;
            }
        }
    }
}
