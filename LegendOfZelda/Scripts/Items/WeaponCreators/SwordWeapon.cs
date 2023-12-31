﻿using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class SwordWeapon : BasicWeapon
    {
        public SwordWeapon(Vector2 linkPosition, int facing, int scale)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateSwordWeaponSprite(facing);
            weaponType = WeaponType.SWORD;
            position = facing switch
            {
                0 => new Vector2(linkPosition.X + 5 * scale, linkPosition.Y + 18 * scale),
                1 => new Vector2(linkPosition.X + 3 * scale, linkPosition.Y - 14 * scale),
                2 => new Vector2(linkPosition.X - 13 * scale, linkPosition.Y + 6 * scale),
                _ => new Vector2(linkPosition.X + 18 * scale, linkPosition.Y + 6 * scale),
            };
            Weapon.Position = position;
        }

        public override void Update(Vector2 linkPosition, int scale)
        {
            if (Weapon != null)
            {
                Weapon.Update();
                AnimationTimer = Weapon.AnimationTimer;
                if (++itemLifeSpan == Weapon.TimeLimit) { DestructionOverride(scale); }
            }
        }

        private void DestructionOverride(int scale)
        {
            Weapon = null;
            weaponType = WeaponType.NONE;
        }

        public override void DestroyWeapon(int scale) { }
    }
}
