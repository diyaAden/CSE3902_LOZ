using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class SwordWeapon : BasicWeapon
    {
        public SwordWeapon(Vector2 linkPosition, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateSwordWeaponSprite(facing);
            weaponType = WeaponType.SWORD;
            position = facing switch
            {
                0 => new Vector2(linkPosition.X + 6, linkPosition.Y + 16),
                1 => new Vector2(linkPosition.X + 4, linkPosition.Y - 16),
                2 => new Vector2(linkPosition.X - 16, linkPosition.Y + 6),
                _ => new Vector2(linkPosition.X + 16, linkPosition.Y + 6),
            };
            Weapon.Position = position;
        }
    }
}
