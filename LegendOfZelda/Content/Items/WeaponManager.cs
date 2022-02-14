using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items
{
    class WeaponManager
    {
        private enum WeaponType { Arrow, Bomb, Fire, Boomerang, Explosion, Other, None}
        public enum Direction { Up, Down, Left, Right}
        private bool magic = false;
        private WeaponType weaponType = WeaponType.None;
        private int timer = 0;
        private IItem weapon { get; set; }
        public Vector2 position { get; set; }

        private void DestroyWeapon()
        {
            //deal with arrows and bombs I think so far
            switch (weaponType)
            {
                case WeaponType.Explosion:
                    weapon = null;
                    weaponType = WeaponType.None;
                    break;
                case WeaponType.Bomb:
                    weapon = WeaponSpriteFactory.Instance.CreateExplosionSprite();
                    weapon.position = position;
                    weaponType = WeaponType.Explosion;
                    break;
                default:
                    break;
            }
        }

        public WeaponManager()
        {
            weapon = null;
            position = new Vector2(0, 0);
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

        public void CreateArrow(Direction facing)
        {
            weaponType = WeaponType.Arrow;
            switch (facing)
            {
                case Direction.Up:
                    weapon = WeaponSpriteFactory.Instance.CreateArrowUpWeaponSprite();
                    weapon.position = position;
                    break;
                default:
                    break;
            }
        }

        public void CreateBomb(Direction facing)
        {
            weaponType = WeaponType.Bomb;
            switch (facing)
            {
                case Direction.Up:
                    weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
                    weapon.position = position;
                    break;
                default:
                    break;
            }
        }
    }
}
