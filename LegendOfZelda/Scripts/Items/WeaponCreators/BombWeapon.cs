using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class BombWeapon : BasicWeapon
    {
        public BombWeapon(Vector2 linkPosition, int facing, int scale)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
            weaponType = WeaponType.BOMB;
            position = facing switch
            {
                0 => new Vector2(linkPosition.X, linkPosition.Y + 16 * scale),
                1 => new Vector2(linkPosition.X, linkPosition.Y - 14 * scale),
                2 => new Vector2(linkPosition.X - 8 * scale, linkPosition.Y),
                _ => new Vector2(linkPosition.X + 16 * scale, linkPosition.Y),
            };
            Weapon.Position = position;
        }
    }
}
