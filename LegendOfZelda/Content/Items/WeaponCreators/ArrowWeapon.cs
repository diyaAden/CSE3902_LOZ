using Microsoft.Xna.Framework;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items.WeaponCreators
{
    class ArrowWeapon : WeaponManager
    {
        public ArrowWeapon(Vector2 pos, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateArrowWeaponSprite(facing);
            weaponType = WeaponType.ARROW;
            position = pos;
            Weapon.position = position;
        }
    }
}
