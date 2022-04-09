using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy.Goriya
{
    public class BoomerangEnemy : Enemy
    {
        private IWeapon boomerang;
        private Vector2 goriyaCenter;

        public BoomerangEnemy(Vector2 goriyaCenter, int direction)
        {
            boomerang = new GoriyaBoomerang(goriyaCenter, direction);
            this.goriyaCenter = goriyaCenter;
            Health = 1;
            position = new Vector2(-100, -100); // so enemy explosion and such aren't visible
        }
        public override Rectangle ObjectBox(int scale)
        {
            return boomerang.ObjectBox(scale);
        }
        public override void Update(Vector2 linkPosition, int scale, Vector2 screenOffset)
        {
            boomerang.Update(goriyaCenter, scale);
            if (boomerang.GetWeaponType() != IWeapon.WeaponType.BOOMERANG) Health = 0;
        }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            boomerang.Draw(spriteBatch, scale);
        }
        public IWeapon.WeaponType GetWeaponType() 
        {
            return boomerang.GetWeaponType();
        }
    }
}
