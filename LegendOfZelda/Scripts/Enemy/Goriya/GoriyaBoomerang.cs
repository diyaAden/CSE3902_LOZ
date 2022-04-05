using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Enemy.Goriya
{
    class GoriyaBoomerang : BasicWeapon
    {
        public GoriyaBoomerang(Vector2 pos, int facing)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateWoodBoomerangWeaponSprite(facing);
            weaponType = WeaponType.BOOMERANG;
            position = pos;
            Weapon.Position = position;
        }

        public override void Update(Vector2 linkPosition, int scale)
        {
            if (Weapon != null)
            {
                Weapon.Update(linkPosition);
                AnimationTimer = Weapon.AnimationTimer;
                if (itemLifeSpan == Weapon.TimeLimit) { DestructionOverride(); }
            }
        }

        private void DestructionOverride()
        {
            if (weaponType == WeaponType.BOOMERANG)
            {
                Weapon = null;
                weaponType = WeaponType.NONE;
            }
        }

        public override void DestroyWeapon(int scale) { }
    }
}
