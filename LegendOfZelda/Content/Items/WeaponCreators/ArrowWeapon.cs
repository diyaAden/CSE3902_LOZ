﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items.WeaponCreators
{
    class ArrowWeapon : WeaponManager
    {
        public ArrowWeapon(Vector2 pos, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateArrowWeaponSprite(facing);
            CurrentWeaponType = WeaponType.Arrow;
            Position = pos;
            Weapon.position = Position;
        }
    }
}
