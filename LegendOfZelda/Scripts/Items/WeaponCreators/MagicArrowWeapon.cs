using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class MagicArrowWeapon : BasicWeapon
    {
        private const int offset = 5;

        public MagicArrowWeapon(Vector2 pos, int facing, int scale)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateMagicArrowWeaponSprite(facing);
            weaponType = WeaponType.ARROW;
            position = facing switch
            {
                0 => new Vector2(pos.X + offset * scale, pos.Y),
                1 => new Vector2(pos.X + offset * scale, pos.Y),
                2 => new Vector2(pos.X, pos.Y + offset * scale),
                _ => new Vector2(pos.X, pos.Y + offset * scale),
            };
            Weapon.Position = position;
        }

        public override void Update(Vector2 linkPosition)
        {
            if (Weapon != null)
            {
                Weapon.Update();
                AnimationTimer = Weapon.AnimationTimer;
                if (++itemLifeSpan == Weapon.TimeLimit) { DestroyWeapon(); }
            }
        }

        public override void DestroyWeapon()
        {
            if (weaponType == WeaponType.ARROW)
            {
                position = Weapon.Position;
                Weapon = WeaponSpriteFactory.Instance.CreateArrowNickSprite();
                Weapon.Position = position;
                weaponType = WeaponType.NICK;
                itemLifeSpan = 0;
            }
            else
            {
                Weapon = null;
                weaponType = WeaponType.NONE;
            }
        }
    }
}
