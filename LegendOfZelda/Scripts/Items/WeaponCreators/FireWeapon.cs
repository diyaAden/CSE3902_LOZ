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
    }
}
