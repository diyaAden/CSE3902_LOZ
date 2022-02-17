using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static LegendOfZelda.Content.Items.IWeapon;

namespace LegendOfZelda.Content.Items
{
    public abstract class WeaponManager : IWeapon
    {
        private int timer = 0;
        protected Vector2 pos = new Vector2();
        protected WeaponType weaponType;
        protected IItem weapon;
        public Vector2 Position {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
            }
        }
        public WeaponType CurrentWeaponType { get; protected set; }

        private void DestroyWeapon()
        {
            switch (CurrentWeaponType)
            {
                case WeaponType.None:
                    break;
                case WeaponType.Bomb:
                    weapon = WeaponSpriteFactory.Instance.CreateExplosionSprite();
                    weapon.position = Position;
                    CurrentWeaponType = WeaponType.Explosion;
                    break;
                case WeaponType.Arrow:
                    Position = weapon.position;
                    weapon = WeaponSpriteFactory.Instance.CreateArrowNickSprite();
                    weapon.position = Position;
                    CurrentWeaponType = WeaponType.Nick;
                    break;
                default:
                    weapon = null;
                    CurrentWeaponType = WeaponType.None;
                    break;
            }
            timer = 0;
        }
        public void Update()
        {
            if (weapon != null)
            {
                weapon.Update();
                if (++timer == weapon.timeLimit) { DestroyWeapon(); }
            }
        }
        public void Update(Vector2 linkPosition)
        {
            if (weapon != null)
            {
                weapon.Update(linkPosition);
                if (timer == weapon.timeLimit) { DestroyWeapon(); }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (weapon != null) { weapon.Draw(spriteBatch); }
        }
    }
}
