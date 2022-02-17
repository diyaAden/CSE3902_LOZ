using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items.WeaponCreators
{
    class BombWeapon : WeaponManager
    {
        public BombWeapon(Vector2 linkPosition, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
            weaponType = WeaponType.Bomb;
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
