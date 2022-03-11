using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links.State;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static LegendOfZelda.Scripts.Items.WeaponManager;

namespace LegendOfZelda.Scripts.Links
{
    public interface ILink
    {
        ILinkState State { get; set; }
        Room CurrentRoom { get; set; }
        public void ToIdle();
        public void MoveUp();
        public void MoveDown();
        public void MoveRight();
        public void MoveLeft();
        public void UseItem();
        public void PickItem();
        public void Attack();
        public void HandleBlockCollision(IGameObject block, ICollision side);
        public void HandleItemCollision(IGameObject item, ICollision side);
        public void HandleItemDestroy(int index);

        public void HandleEnemyCollision(IEnemy enemy, ICollision side);
        void Update();
        void Draw(SpriteBatch spriteBatch, int scale);
    }
}
