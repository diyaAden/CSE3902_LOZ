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
        protected IItem Weapon;
        protected Vector2 position;

        private void DestroyWeapon()
        {
            switch (weaponType)
            {
                case WeaponType.None:
                    break;
                case WeaponType.Bomb:
                    Weapon = WeaponSpriteFactory.Instance.CreateExplosionSprite();
                    Weapon.position = position;
                    weaponType = WeaponType.Explosion;
                    break;
                case WeaponType.Arrow:
                    position = Weapon.position;
                    Weapon = WeaponSpriteFactory.Instance.CreateArrowNickSprite();
                    Weapon.position = position;
                    weaponType = WeaponType.Nick;
                    break;
                default:
                    Weapon = null;
                    weaponType = WeaponType.None;
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
            if (weaponType == WeaponType.Boomerang)
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
