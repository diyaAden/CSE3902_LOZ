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

        public WeaponManager(Vector2 pos)
        {
            weapon = null;
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

        public void BecomeArrow(Direction facing)
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

        public void BecomeBomb(Direction facing)
        {
            weaponType = WeaponType.Bomb;
            switch (facing)
            {
                case Direction.Up:
                    weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
                    weapon.position = new Vector2(position.X, position.Y - 16);
                    break;
                case Direction.Down:
                    weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
                    weapon.position = new Vector2(position.X, position.Y + 16);
                    break;
                case Direction.Left:
                    weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
                    weapon.position = new Vector2(position.X - 16, position.Y);
                    break;
                default:
                    weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
                    weapon.position = new Vector2(position.X + 16, position.Y);
                    break;
            }
        }
    }
}
