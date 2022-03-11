using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy
{
    public interface IEnemy //Should be IGameObject later
    {
        public Vector2 position { get; set; }

        public void Attack();
        void HandleBlockCollision(IGameObject block, ICollision side);
        void HandleWeaponCollision(IGameObject weapon, ICollision side);

        public void Update(int scale);

        public Rectangle ObjectBox(int scale);

        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}
