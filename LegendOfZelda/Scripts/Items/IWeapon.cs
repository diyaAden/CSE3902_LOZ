using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items
{
    public interface IWeapon
    {
        public enum WeaponType { ARROW, BOMB, FIRE, BOOMERANG, SWORD, SWORDSHARDS, EXPLOSION, NICK, NONE }

        public Vector2 GetPosition();

        public WeaponType GetWeaponType();

        public void Update(Vector2 linkPosition);

        public void Draw(SpriteBatch spriteBatch);
    }
}
