﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items
{
    public abstract class BasicWeapon : IWeapon
    {
        private int timer = 0;
        protected WeaponType weaponType;
        protected IItem Weapon;
        protected Vector2 position;

        private void DestroyWeapon()
        {
            position = Weapon.Position;
            switch (weaponType)
            {
                case WeaponType.BOMB:
                    Weapon = WeaponSpriteFactory.Instance.CreateExplosionSprite();
                    Weapon.Position = position;
                    weaponType = WeaponType.EXPLOSION;
                    break;
                case WeaponType.ARROW:
                    Weapon = WeaponSpriteFactory.Instance.CreateArrowNickSprite();
                    Weapon.Position = position;
                    weaponType = WeaponType.NICK;
                    break;
                case WeaponType.SWORD:
                    Weapon = WeaponSpriteFactory.Instance.CreateSwordShardSetWeaponSprite(position);
                    weaponType = WeaponType.SWORDSHARDS;
                    break;
                default:
                    Weapon = null;
                    weaponType = WeaponType.NONE;
                    break;
            }
            timer = 0;
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        public WeaponType GetWeaponType()
        {
            return weaponType;
        }
        public void Update(Vector2 linkPosition)
        {
            if (weaponType == WeaponType.BOOMERANG)
            {
                Weapon.Update(linkPosition);
                if (timer == Weapon.TimeLimit) { DestroyWeapon(); }
            }
            else if (Weapon != null)
            {
                Weapon.Update();
                if (++timer == Weapon.TimeLimit) { DestroyWeapon(); }
            }
        }

        public virtual bool IsNull()
        {
            return Weapon == null;
        }
        public virtual Rectangle ObjectBox(int scale)
        {
            return Weapon.ObjectBox(scale);
        }
        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            if (Weapon != null) { Weapon.Draw(spriteBatch, scale); }
        }
    }
}