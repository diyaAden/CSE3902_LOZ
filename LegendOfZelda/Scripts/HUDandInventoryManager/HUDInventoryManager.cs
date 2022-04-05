using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class HUDInventoryManager
    {
        private readonly int xPos = 250, yPos = 10, width = 256, height = 60;

        public int rupees;
        public int keys;
        public bool hasMap;
        public float health;
     
        public HUDInventoryManager()
        {
           // SpriteSheet = HUDTexture;
            //sourceRect = new Rectangle(xPos, yPos, width, height);
            //destRectangle = new Rectangle()
        }

        public void updateRupees()
        {

        }

        public void updateKeys()
        {

        }

        public void updateHealth()
        {

        }
        public void Update() 
        { 
            //update lives
            //check color for map
        }

    }
}
