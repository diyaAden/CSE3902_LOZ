using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class ArrowWeapon : BasicWeapon
    {
        public ArrowWeapon(Vector2 pos, int facing, int scale)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateArrowWeaponSprite(facing);
            weaponType = WeaponType.ARROW;
            position = facing switch
            {
                0 => new Vector2(pos.X + 5 * scale, pos.Y),
                1 => new Vector2(pos.X + 5 * scale, pos.Y),
                2 => new Vector2(pos.X, pos.Y + 5 * scale),
                _ => new Vector2(pos.X, pos.Y + 5 * scale),
            };
            Weapon.Position = position;
        }
    }
}
