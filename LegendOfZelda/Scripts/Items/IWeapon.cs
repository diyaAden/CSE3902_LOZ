using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items
{
    public interface IWeapon: IGameObject
    {
        public enum WeaponType { ARROW, BOMB, FIRE, BOOMERANG, SWORD, SWORDBEAM, SWORDSHARDS, EXPLOSION, NICK, NONE }

        public Vector2 GetPosition();
        public int AnimationTimer { get; set; }

        public void DestroyWeapon(int scale);

        public WeaponType GetWeaponType();

        public bool IsNull();

        public void Update(Vector2 linkPosition, int scale);

        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}
