using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
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
