using LegendOfZelda.Scripts.Items.WeaponSprites;
using Microsoft.Xna.Framework;
using static LegendOfZelda.Scripts.Items.IWeapon;

namespace LegendOfZelda.Scripts.Items.WeaponCreators
{
    class ArrowWeapon : BasicWeapon
    {
        private const int offset = 5;

        public ArrowWeapon(Vector2 pos, int facing, int scale)
        {
            Weapon = WeaponSpriteFactory.Instance.CreateArrowWeaponSprite(facing);
            weaponType = WeaponType.ARROW;
            position = facing switch
            {
                0 => new Vector2(pos.X + offset * scale, pos.Y),
                1 => new Vector2(pos.X + offset * scale, pos.Y),
                2 => new Vector2(pos.X, pos.Y + offset * scale),
                _ => new Vector2(pos.X, pos.Y + offset * scale),
            };
            Weapon.Position = position;
        }

        public override void Update(Vector2 linkPosition)
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
            if (weaponType == WeaponType.ARROW) DestroyWeapon();
            else
            {
                Weapon = null;
                weaponType = WeaponType.NONE;
            }
        }

        public override void DestroyWeapon()
        {
            if (weaponType == WeaponType.ARROW) {
                position = Weapon.Position;
                Rectangle arrowBox = Weapon.ObjectBox(2);
                int direction = ((ArrowWeaponSprite)Weapon).Direction;
                Weapon = WeaponSpriteFactory.Instance.CreateArrowNickSprite();
                Rectangle nickBox = Weapon.ObjectBox(2);
                if (direction == 3) position.X = position.X + arrowBox.Width - nickBox.Width;
                else if (direction == 0) position.Y = position.Y + arrowBox.Height - nickBox.Height;
                Weapon.Position = position;
                weaponType = WeaponType.NICK;
                itemLifeSpan = 0;
            }
        }
    }
}
