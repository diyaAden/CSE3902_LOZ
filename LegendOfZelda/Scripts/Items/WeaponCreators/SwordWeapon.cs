using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class SwordWeapon : BasicWeapon
    {
        public SwordWeapon(Vector2 linkPosition, int facing, int scale)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateSwordWeaponSprite(facing);
            weaponType = WeaponType.SWORD;
            position = facing switch
            {
                0 => new Vector2(linkPosition.X + 3 * scale, linkPosition.Y + 8 * scale),
                1 => new Vector2(linkPosition.X + 2 * scale, linkPosition.Y - 8 * scale),
                2 => new Vector2(linkPosition.X - 8 * scale, linkPosition.Y + 3 * scale),
                _ => new Vector2(linkPosition.X + 8 * scale, linkPosition.Y + 3 * scale),
            };
            Weapon.Position = position;
        }
    }
}
