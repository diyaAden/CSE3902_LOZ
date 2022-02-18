using Microsoft.Xna.Framework;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items.WeaponCreators
{
    class FireWeapon : WeaponManager
    {
        public FireWeapon(Vector2 pos, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateFireWeaponSprite(facing);
            weaponType = WeaponType.FIRE;
            position = pos;
            Weapon.position = position;
        }
    }
}
