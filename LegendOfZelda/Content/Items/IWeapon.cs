using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items
{
    public interface IWeapon
    {
        public enum WeaponType { Arrow, Bomb, Fire, Boomerang, Explosion, Nick, None }
        public Vector2 Position { get; protected set; }
        public WeaponType CurrentWeaponType { get; protected set; }

        public void Update();

        public void Update(Vector2 linkPosition);

        public void Draw(SpriteBatch spriteBatch);
    }
}
