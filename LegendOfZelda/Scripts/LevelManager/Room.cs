using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
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
    }
}
