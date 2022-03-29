using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class MagicBoomerangWeapon : BasicWeapon
    {
        public MagicBoomerangWeapon(Vector2 pos, int facing)
        {
            SoundController.Instance.StartBoomerangSound();
            Weapon = WeaponSpriteFactory.Instance.CreateMagicBoomerangWeaponSprite(facing);
            weaponType = WeaponType.BOOMERANG;
            position = pos;
            Weapon.Position = position;
        }
    }
}
