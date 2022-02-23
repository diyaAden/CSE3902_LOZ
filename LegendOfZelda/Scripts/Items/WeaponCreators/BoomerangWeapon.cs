using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class BoomerangWeapon : WeaponManager
    {
        public BoomerangWeapon(Vector2 pos, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateWoodBoomerangWeaponSprite(facing);
            weaponType = WeaponType.BOOMERANG;
            position = pos;
            Weapon.position = position;
        }
    }
}
