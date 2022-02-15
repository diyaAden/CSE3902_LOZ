using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items
{
    class WeaponManager
    {
        public enum WeaponType { Arrow, Bomb, Fire, Boomerang, Explosion, Nick, Other, None}
        public WeaponType weaponType { get; private set; }
        private int timer = 0;
        private IItem weapon { get; set; }
        public Vector2 position { get; set; }

        private void DestroyWeapon()
        {
            switch (weaponType)
            {
                case WeaponType.Fire:
                case WeaponType.Nick:
                case WeaponType.Explosion:
                    weapon = null;
                    weaponType = WeaponType.None;
                    break;
                case WeaponType.Bomb:
                    weapon = WeaponSpriteFactory.Instance.CreateExplosionSprite();
                    weapon.position = position;
                    weaponType = WeaponType.Explosion;
                    break;
                case WeaponType.Arrow:
                    position = weapon.position;
                    weapon = WeaponSpriteFactory.Instance.CreateArrowNickSprite();
                    weapon.position = position;
                    weaponType = WeaponType.Nick;
                    break;
                default:
                    break;
            }
        }

        public WeaponManager(Vector2 pos)
        {
            weapon = null;
            weaponType = WeaponType.None;
            position = pos;
        }

        public IItem CurrentWeapon()
        {
            return weapon;
        }

        public void Update()
        {
            if (weapon != null)
            {
                weapon.Update();
                if (++timer == weapon.timeLimit)
                {
                    DestroyWeapon();
                    timer = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (weapon != null)
            {
                weapon.Draw(spriteBatch);
            }
        }

        public void BecomeArrow(int facing)
        {
            weaponType = WeaponType.Arrow;
            weapon = WeaponSpriteFactory.Instance.CreateArrowWeaponSprite(facing);
            weapon.position = position;
        }

        public void BecomeMagicArrow(int facing)
        {
            weaponType = WeaponType.Arrow;
            weapon = WeaponSpriteFactory.Instance.CreateMagicArrowWeaponSprite(facing);
            weapon.position = position;
        }

        public void BecomeFire(int facing)
        {
            weaponType = WeaponType.Fire;
            weapon = WeaponSpriteFactory.Instance.CreateFireWeaponSprite(facing);
            weapon.position = position;
        }

        public void BecomeBomb(int facing)
        {
            weaponType = WeaponType.Bomb;
            weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
            switch (facing)
            {
                case 1:
                    position = new Vector2(position.X, position.Y - 16);
                    break;
                case 0:
                    position = new Vector2(position.X, position.Y + 16);
                    break;
                case 2:
                    position = new Vector2(position.X - 16, position.Y);
                    break;
                default:
                    position = new Vector2(position.X + 16, position.Y);
                    break;
            }
            weapon.position = position;
        }
    }
}
