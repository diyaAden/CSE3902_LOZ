using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class BoomerangWeapon : BasicWeapon
    {
        public BoomerangWeapon(Vector2 pos, int facing)
        {
            SoundController.Instance.StartBoomerangSound();
            Weapon = WeaponSpriteFactory.Instance.CreateWoodBoomerangWeaponSprite(facing);
            weaponType = WeaponType.BOOMERANG;
            position = pos;
            Weapon.Position = position;
        }

        public override void Update(Vector2 linkPosition)
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
                SoundController.Instance.StopBoomerangSound();
                Weapon = null;
                weaponType = WeaponType.NONE;
            }
        }

        public override void DestroyWeapon() { }
    }
}
