using System.Diagnostics;
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
        private float maxHealth = 4;
        private int HeartposX = 179;
        private int HeartposY = 36;
        private int lastHeart;
        private int firstEmpty;
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
            for (int w = 0; w < maxHealth; w++)
            {
                HUD.AddHearts("HeartItem", HeartposX, HeartposY);
                if(!((w+1)==maxHealth))
                HeartposX += 8;
            }
            lastHeart = (int) maxHealth - 1;
        }
        public void damageLink() {
            health -= 0.5f;
            if (health % 1 == 0)
            {
                HUD.ChangeHeart("EmptyHeart", lastHeart);
                firstEmpty = lastHeart;
                lastHeart--;
            } else
            {
                HUD.ChangeHeart("HalfHeart", lastHeart);
            }
            Debug.WriteLine("Health is {0}, lastHeart: {1}", health, lastHeart);
            Debug.WriteLine("LastHeart name: " + HUD.Hearts[lastHeart].name);
            
        }
        public void gainHeart() {
            if (!(firstEmpty > 0) && (health == maxHealth))
            {
                HeartposX += 8;
                HUD.AddHearts("HeartItem", HeartposX, HeartposY);
                lastHeart++;
            }
            else
            {
                if (health % 1 == 0)
                {
                    HUD.ChangeHeart("FullHeart", firstEmpty);
                    firstEmpty = lastHeart;
                    firstEmpty++;
                    health += 1.0f;
                }
                else
                {
                    if (health == (maxHealth - 0.5f))
                    {
                        //HeartposX += 8;
                        HUD.ChangeHeart("FullHeart", lastHeart);
                        //HUD.AddHearts("HalfHeartItem", HeartposX, HeartposY);
                        lastHeart++;
                        health += 0.5f;
                    }
                    else
                    {
                        HUD.ChangeHeart("FullHeart", lastHeart);
                        HUD.ChangeHeart("HalfHeart", firstEmpty);
                        firstEmpty++;
                        lastHeart++;
                        health += 1.0f;
                    }
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
            if(health == 0) {
               //End the game
            }

            

        }
        public void Update()
        {
            updateHealth();
        }
        


    }
}
