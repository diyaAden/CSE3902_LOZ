using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items.WeaponCreators
{
    class MagicBoomerangWeapon : WeaponManager
    {
        public MagicBoomerangWeapon(Vector2 pos, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateMagicBoomerangWeaponSprite(facing);
            weaponType = WeaponType.Boomerang;
            position = pos;
            Weapon.position = position;
        }
    }
}
