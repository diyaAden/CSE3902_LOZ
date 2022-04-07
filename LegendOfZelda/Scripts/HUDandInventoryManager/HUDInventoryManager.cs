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
        public HUDSprite HUD { get; set; }

        public HUDInventoryManager(HUDSprite HUDG)
        {
            HUD = HUDG;
        }
        public void LoadContent()
        {
            int numberOfHearts = 17;
            int HeartposX = 179;
            int HeartposY = 36;
            //Add hearts
            for (int i = 1; i < numberOfHearts; i++) {
                HUD.AddObject("HeartItem", HeartposX, HeartposY);
                HeartposX += 8;
                if(i == 8) {
                    HeartposY += 8;
                    HeartposX = 179;
                }

            }
        }
        public void updateRupees()
        {

        }

        public void updateKeys()
        {

        }

        public void updateHealth()
        {
            int lastHeart = HUD.findLastHeart();
            HUD.RemoveObject(lastHeart);
        }
        public void Update()
        {
            updateHealth();
            //update lives
            //check color for map
        }
        


    }
}
