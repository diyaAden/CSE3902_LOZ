using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class FireWeapon : BasicWeapon
    {
        public FireWeapon(Vector2 pos, int facing)
        {
            SoundController.Instance.StartFireSound();
            Weapon = WeaponSpriteFactory.Instance.CreateFireWeaponSprite(facing);
            weaponType = WeaponType.FIRE;
            position = pos;
            Weapon.Position = position;
        }

        public override void Update(Vector2 linkPosition, int scale)
        {
            if (Weapon != null)
            {
                Weapon.Update();
                AnimationTimer = Weapon.AnimationTimer;
                if (++itemLifeSpan == Weapon.TimeLimit) { DestructionOverride(); }
            }
        }

        private void DestructionOverride()
        {
            if (weaponType == WeaponType.FIRE)
            {
                SoundController.Instance.StopFireSound();
                Weapon = null;
                weaponType = WeaponType.NONE;
            }
        }

        public override void DestroyWeapon(int scale) { }
    }
}
