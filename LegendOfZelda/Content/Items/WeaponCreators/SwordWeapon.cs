using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items.WeaponCreators
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
