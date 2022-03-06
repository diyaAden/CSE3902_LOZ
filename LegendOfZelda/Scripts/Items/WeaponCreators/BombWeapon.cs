using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class BombWeapon : WeaponManager
    {
        public BombWeapon(Vector2 linkPosition, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
            weaponType = WeaponType.BOMB;
            position = facing switch
            {
                0 => new Vector2(linkPosition.X, linkPosition.Y + 16),
                1 => new Vector2(linkPosition.X, linkPosition.Y - 16),
                2 => new Vector2(linkPosition.X - 16, linkPosition.Y),
                _ => new Vector2(linkPosition.X + 16, linkPosition.Y),
            };
            Weapon.Position = position;
        }
    }
}
