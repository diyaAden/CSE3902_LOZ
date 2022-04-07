using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Links
{
    public interface ILink
    {
        ILinkState State { get; set; }
        public void ToIdle();
        public void MoveUp();
        public void MoveDown();
        public void MoveRight();
        public void MoveLeft();
        public void UseItem();
        public void PickItem(string name, int scale);
        public void Attack(int scale);
        public void HandleBlockCollision(IGameObject block, ICollision side);
        public void HandleDoorCollision(int direction, int scale);
        public void HandleItemCollision(IGameObject item, ICollision side, int scale);
        public void HandleWeaponCollision(IGameObject gameObject, ICollision side);

        public void addInventoryItem(IGameObject gameObject);
        public void HandleEnemyCollision(IEnemy enemy, ICollision side);
        void Update();
        void Draw(SpriteBatch spriteBatch, int scale);
    }
}
