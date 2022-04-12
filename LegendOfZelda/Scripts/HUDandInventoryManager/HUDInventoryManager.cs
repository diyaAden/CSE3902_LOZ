using System.Diagnostics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class HUDInventoryManager
    {
        private readonly int xPos = 250, yPos = 10, width = 256, height = 60;

        public int rupees;
        public int keys;
        public bool hasMap = true;
        public float health = 4;
        private float maxHealth = 4;
        private int HeartposX = 179;
        private int HeartposY = 36;
        private int lastHeart;
        private int firstEmpty;
        public HUDSprite HUD { get; set; }
      

        //List<IGameObject> invDisplayItems = new List<IGameObject>();
        

        public HUDInventoryManager(HUDSprite HUDG)
        {
            HUD = HUDG;
            health = maxHealth;
        }
        public bool IsFullHealth() { return health == maxHealth; }
        public void LoadContent()
        {
            
            int numberOfSpaces = 17;
            int BlackSpaceX = 99;
            int BlackSpaceY = 20;
            for(int w = 0; w < 9; w++)
            {
                HUD.AddObject("BlackSpace", BlackSpaceX, BlackSpaceY);
                BlackSpaceX += 8;
                if (w == 2)
                {
                    BlackSpaceY += 16;
                    BlackSpaceX = 99;
                }
                if (w == 5)
                {
                    BlackSpaceY += 8;
                    BlackSpaceX = 99;
                }
            }

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
            
            if (health % 1 != 0)
            {
                HUD.ChangeHeart("EmptyHeart", lastHeart);
                firstEmpty = lastHeart;
                lastHeart--;
            } else
            {
                HUD.ChangeHeart("HalfHeart", lastHeart);
            }
            health -= 0.5f;
            Debug.WriteLine("Health is {0}, lastHeart: {1}", health, lastHeart);
            
            
        }
        public void gainHeart() {
            if (health == maxHealth)
            {
                //DO Nothing
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

                        HUD.ChangeHeart("FullHeart", lastHeart);
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
