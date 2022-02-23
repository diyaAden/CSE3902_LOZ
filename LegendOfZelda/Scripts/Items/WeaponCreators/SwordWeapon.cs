using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class SwordWeapon : WeaponManager
    {
        public SwordWeapon(Vector2 linkPosition, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateSwordWeaponSprite(facing);
            weaponType = WeaponType.SWORD;
            switch (facing)
            {
                case 0:
                    position = new Vector2(linkPosition.X + 6, linkPosition.Y + 16);
                    break;
                case 1:
                    position = new Vector2(linkPosition.X + 4, linkPosition.Y - 16);
                    break;
                case 2:
                    position = new Vector2(linkPosition.X - 16, linkPosition.Y + 6);
                    break;
                default:
                    position = new Vector2(linkPosition.X + 16, linkPosition.Y + 6);
                    break;
            }
            Weapon.position = position;
        }
    }
}
