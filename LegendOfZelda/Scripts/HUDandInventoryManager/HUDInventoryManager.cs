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
        private float maxHealth = 5;
        private int HeartposX = 179;
        private int HeartposY = 36;
        private bool healthChanged = true;
        public HUDSprite HUD { get; set; }

        public HUDInventoryManager(HUDSprite HUDG)
        {
            HUD = HUDG;
        }
        public void LoadContent()
        {
            int numberOfSpaces = 17;
            //Add hearts
            for (int i = 1; i < numberOfSpaces; i++) {
                HUD.AddObject("BlackSpace", HeartposX, HeartposY);
                HeartposX += 8;
                if(i == 8) {
                    HeartposY += 8;
                    HeartposX = 179;
                }

            }
            HeartposX = 179;
            HeartposY = 36;
            //for(int w = 0; w < 4; w++)
            //{
            //    HUD.AddHearts("HeartItem", HeartposX, HeartposY);
            //    HeartposX += 8;
            //}
            
        }
        public void damageLink() {
            health -= 0.5f;
            healthChanged = true;
            //HUD.RemoveHeart();
            //HeartposX -= 8;
            //if(HeartposX < 179) {
            //    HeartposX = 179;
            //}

            //if(health % 1 == 0.5) {
            //    HUD.AddHearts("HalfHeartItem", HeartposX, HeartposY);
            //}
        }
        public void gainHeart() {
            health += 1.0f;
            healthChanged = true;
            //HUD.AddHearts("HeartItem", HeartposX, HeartposY);
            //HeartposX += 8;
        }


        public void updateRupees()
        {

        }

        public void updateKeys()
        {

        }

        public void updateHealth()
        {
            if (healthChanged)
            {
                for (int i = 0; i < maxHealth; i++)
                {
                    if (i < health)
                    {
                        HUD.AddHearts("HeartItem", HeartposX, HeartposY);
                        HeartposX += 8;
                    }
                    else if (i + 0.5f == health)
                    {
                        HUD.AddHearts("HalfHeartItem", HeartposX, HeartposY);
                        HeartposX += 8;
                    }
                    else
                    {
                        HUD.AddHearts("EmptyHeartItem", HeartposX, HeartposY);
                        HeartposX -= 8;
                    }
                }
                
            }
            HeartposX = 179;
            healthChanged = false;

        }
        public void Update()
        {
            updateHealth();
            //update lives
            //check color for map
        }
        


    }
}
