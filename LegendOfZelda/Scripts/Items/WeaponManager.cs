﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items
{
    public abstract class WeaponManager : IWeapon
    {
        private int timer = 0;
        protected WeaponType weaponType;
        protected IItem Weapon;
        protected Vector2 position;

        private void DestroyWeapon()
        {
            position = Weapon.position;
            switch (weaponType)
            {
                case WeaponType.BOMB:
                    Weapon = WeaponSpriteFactory.Instance.CreateExplosionSprite();
                    Weapon.position = position;
                    weaponType = WeaponType.EXPLOSION;
                    break;
                case WeaponType.ARROW:
                    Weapon = WeaponSpriteFactory.Instance.CreateArrowNickSprite();
                    Weapon.position = position;
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
                if (timer == Weapon.timeLimit) { DestroyWeapon(); }
            }
            else if (Weapon != null)
            {
                Weapon.Update();
                if (++timer == Weapon.timeLimit) { DestroyWeapon(); }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Weapon != null) { Weapon.Draw(spriteBatch); }
        }
    }
}