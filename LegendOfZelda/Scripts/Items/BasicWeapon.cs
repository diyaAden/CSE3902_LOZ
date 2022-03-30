using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items
{
    public abstract class BasicWeapon : IWeapon
    {
        public int AnimationTimer { get { return animationTimer; } set { animationTimer = value; } }
        private int animationTimer = 1;
        protected int itemLifeSpan = 0;

        protected WeaponType weaponType;
        protected IItem Weapon;
        protected Vector2 position;

        public virtual void DestroyWeapon()
        {
            position = Weapon.Position;
            switch (weaponType)
            {
                case WeaponType.BOMB:
                    Weapon = WeaponSpriteFactory.Instance.CreateExplosionSprite();
                    Weapon.Position = position;
                    weaponType = WeaponType.EXPLOSION;
                    break;
                default:
                    Weapon = null;
                    weaponType = WeaponType.NONE;
                    break;
            }
            itemLifeSpan = 0;
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        public WeaponType GetWeaponType()
        {
            return weaponType;
        }
        public virtual void Update(Vector2 linkPosition)
        {
            if (Weapon != null)
            {
                Weapon.Update();
                AnimationTimer = Weapon.AnimationTimer;
                if (++itemLifeSpan == Weapon.TimeLimit) { DestroyWeapon(); }
            }
        }

        public virtual bool IsNull()
        {
            return Weapon == null;
        }
        public virtual void HandleCollision(ICollision side, int scale) { }
        public virtual Rectangle ObjectBox(int scale)
        {
            if (Weapon == null) return new Rectangle();
            else return Weapon.ObjectBox(scale);
        }
        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            if (Weapon != null) { Weapon.Draw(spriteBatch, scale); }
        }
    }
}
