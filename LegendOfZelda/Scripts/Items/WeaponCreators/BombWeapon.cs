using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class BombWeapon : BasicWeapon
    {
        private const int offsetS = 16, offsetN = -14, offsetW = -8, offsetE = 16;

        public BombWeapon(Vector2 linkPosition, int facing, int scale)
        {
            SoundController.Instance.PlayBombSound();
            Weapon = WeaponSpriteFactory.Instance.CreateBombWeaponSprite();
            weaponType = WeaponType.BOMB;
            position = facing switch
            {
                0 => new Vector2(linkPosition.X, linkPosition.Y + offsetS * scale),
                1 => new Vector2(linkPosition.X, linkPosition.Y + offsetN * scale),
                2 => new Vector2(linkPosition.X + offsetW * scale, linkPosition.Y),
                _ => new Vector2(linkPosition.X + offsetE * scale, linkPosition.Y),
            };
            Weapon.Position = position;
        }
    }
}
