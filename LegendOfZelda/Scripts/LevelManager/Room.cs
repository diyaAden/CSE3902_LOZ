using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room
    {
        public List<IItem> Items { get; private set; }
        public List<IEnemy> Enemies { get; private set; }
        public List<IBlock> Blocks { get; private set; }

        public Room() 
        {
            Items = new List<IItem>();
            Enemies = new List<IEnemy>();
            Blocks = new List<IBlock>();
        }

        public void Update()
        {
            foreach (IItem item in Items)
            {
                item.Update();
            }
            foreach (IBlock block in Blocks)
            {
                block.Update();
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
            }
            foreach (IBlock block in Blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
