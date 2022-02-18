using Microsoft.Xna.Framework;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items.WeaponCreators
{
    class MagicArrowWeapon : WeaponManager
    {
        public MagicArrowWeapon(Vector2 pos, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateMagicArrowWeaponSprite(facing);
            weaponType = WeaponType.ARROW;
            position = pos;
            Weapon.position = position;
        }
    }
}
