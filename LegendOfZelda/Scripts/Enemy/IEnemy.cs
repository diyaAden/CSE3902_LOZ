using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy
{
    public interface IEnemy : IGameObject
    {
        public Vector2 position { get; set; }
        public int Health { get; set; }
        public void Attack();
        void HandleBlockCollision(IGameObject block, ICollision side, int scale);
        void HandleWeaponCollision(IGameObject weapon, ICollision side);

        public void Update(Vector2 linkPosition, int scale, Vector2 screenOffset);

        public void Update(int scale, Vector2 screenOffset);

        public Rectangle ObjectBox(int scale);

        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}
