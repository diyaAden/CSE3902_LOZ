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
            switch (facing)
            {
                case 0:
                    position = new Vector2(linkPosition.X, linkPosition.Y + 16);
                    break;
                case 1:
                    position = new Vector2(linkPosition.X, linkPosition.Y - 16);
                    break;
                case 2:
                    position = new Vector2(linkPosition.X - 16, linkPosition.Y);
                    break;
                default:
                    position = new Vector2(linkPosition.X + 16, linkPosition.Y);
                    break;
            }
            Weapon.position = position;
        }
    }
}
