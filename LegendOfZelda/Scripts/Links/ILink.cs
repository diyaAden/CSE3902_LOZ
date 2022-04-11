using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace LegendOfZelda.Scripts.Links
{
    public interface ILink
    {
        public bool HasClock { get; }
        public int numRupees { get; set; }
        public int numKeys { get; set; }
        public int numBombs { get; set; }
        ILinkState State { get; set; }
        int CatchByEnemy { get; set; }
        public void ToIdle();
        public void GameOverLink();
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
        public bool hasArrows();
        public bool hasBombs();
        public bool HasKeys();
        public List<IItem> getInventoryList();
        public void addInventoryItem(IItem gameObject);
        public void HandleEnemyCollision(IEnemy enemy, ICollision side);
        public void HandleEnemyCollision(IEnemy enemy,int scale);
        void Update();
        void Draw(SpriteBatch spriteBatch, int scale);
    }
}
