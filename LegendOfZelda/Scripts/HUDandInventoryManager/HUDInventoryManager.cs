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
        public float health = 4;
        private float lastHealth;
        private int HeartposX = 179;
        private int HeartposY = 36;
        public HUDSprite HUD { get; set; }

        public HUDInventoryManager(HUDSprite HUDG)
        {
            HUD = HUDG;
        }
        public void LoadContent()
        {
            int numberOfHearts = 17;
            //Add hearts
            for (int i = 1; i < numberOfHearts; i++) {
                HUD.AddObject("BlackSpace", HeartposX, HeartposY);
                HeartposX += 8;
                if(i == 8) {
                    HeartposY += 8;
                    HeartposX = 179;
                }

            }
            for(int w = 0; w < 4; w++)
            {
                HUD.AddHearts("HeartItem", HeartposX, HeartposY);
            }
            
        }
        public void damageLink() {
            health -= 0.5f;
        }

        public void updateRupees()
        {

        }

        public void updateKeys()
        {

        }

        public void updateHealth()
        {
            for(int w = 1; w <= HUD.Hearts.Count; w++) {
                if (!((w - health) == 0.5))
                {

                    if (w < health)
                    {
                        HUD.AddHearts("HeartItem", HeartposX, HeartposY);
                    }
                    else if (w > health)
                    {
                        HUD.AddHearts("EmptyHeartItem", HeartposX, HeartposY);
                    }
                }else {
                    HUD.AddHearts("HalfHeartItem", HeartposX, HeartposY);
                }
                HeartposX += 8;



            }

        }
        public void Update()
        {
            updateHealth();
            //update lives
            //check color for map
        }
        


    }
}
