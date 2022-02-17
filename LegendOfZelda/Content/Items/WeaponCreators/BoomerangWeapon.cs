﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items.WeaponCreators
{
    class BoomerangWeapon : WeaponManager
    {
        public BoomerangWeapon(Vector2 pos, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateWoodBoomerangWeaponSprite(facing);
            CurrentWeaponType = WeaponType.Boomerang;
            Position = pos;
            Weapon.position = Position;
        }
    }
}
