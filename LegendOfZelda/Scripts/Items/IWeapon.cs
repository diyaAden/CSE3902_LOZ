using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items
{
    public interface IWeapon: IGameObject
    {
        public enum WeaponType { ARROW, BOMB, FIRE, BOOMERANG, SWORDBEAM, SWORDSHARDS, EXPLOSION, NICK, NONE }

        public Vector2 GetPosition();
        public int AnimationTimer { get; set; }

        public void DestroyWeapon();

        public WeaponType GetWeaponType();

        public bool IsNull();

        public void Update(Vector2 linkPosition);

        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}
