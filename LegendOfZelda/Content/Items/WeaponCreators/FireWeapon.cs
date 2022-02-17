using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items.WeaponCreators
{
    class FireWeapon : WeaponManager
    {
        public FireWeapon(Vector2 pos, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateFireWeaponSprite(facing);
            weaponType = WeaponType.Fire;
            position = pos;
            Weapon.position = position;
        }
    }
}
