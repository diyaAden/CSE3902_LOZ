using Microsoft.Xna.Framework;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items.WeaponCreators
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
