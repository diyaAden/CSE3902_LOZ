using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items
{
    public interface IWeapon
    {
        public enum WeaponType { Arrow, Bomb, Fire, Boomerang, Explosion, Nick, None }

        public Vector2 GetPosition();

        public WeaponType GetWeaponType();

        public void Update(Vector2 linkPosition);

        public void Draw(SpriteBatch spriteBatch);
    }
}
