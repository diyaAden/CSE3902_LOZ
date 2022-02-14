using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items
{
    class WeaponManager
    {
        private enum WeaponType { Arrow, Bomb, Fire, Boomerang, Explosion, Other}
        public enum Direction { Up, Down, Left, Right}
        private bool magic = false;
        private WeaponType weaponType;
        private Direction direction;
        private IItem weapon = null;
        private Texture2D smokeCloud;
        private int timer = 0;

        private void DestroyWeapon()
        {
            //deal with arrows and bombs I think so far
        }

        public WeaponManager(ContentManager content)
        {
            //smokeCloud = content.Load<Texture2D>("SpreteSheets/Items/WeaponParticlesSpreteSheet.png");
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
            direction = facing;
            weaponType = WeaponType.Arrow;
            weapon = WeaponSpriteFactory.Instance.CreateArrowUpWeaponSprite();
        }
    }
}
