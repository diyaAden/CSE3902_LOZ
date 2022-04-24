using System.Diagnostics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class HealthManager
    {
        public int rupees, keys;
        public bool hasMap = true;
        public float hearts = 4f;
        private float maxHearts = 4f, halfHeart = 0.5f, fullHeart = 1f;
        private int HeartposX = 179, HeartposY = 36;
        private int firstEmpty, lastHeart;
        public HUDSprite HUD { get; set; }
        private bool firstTime = true;
        
        public HealthManager(HUDSprite HUDG)
        {
            HUD = HUDG;
        }
        public bool IsFullHealth() { return hearts == maxHearts; }
        public void LoadContent()
        {
            int numberOfSpaces = 17;
            int BlackSpaceX = 99;
            int BlackSpaceY = 20;
            if (firstTime)
            {
                //Add extra black space for HUD
                for (int w = 0; w < 9; w++)
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

                //Add Blackspace for Hearts
                for (int i = 1; i < numberOfSpaces; i++)
                {
                    HUD.AddObject("BlackSpace", HeartposX, HeartposY);
                    HeartposX += 8;
                    if (i == 8)
                    {
                        HeartposY += 8;
                        HeartposX = 179;
                    }

                }
                HeartposX = 179;
                HeartposY = 36;
                //Add hearts
                for (int w = 0; w < maxHearts; w++)
                {
                    HUD.AddHearts("HeartItem", HeartposX, HeartposY);
                    if (!((w + 1) == maxHearts))
                        HeartposX += 8;
                }
                lastHeart = (int)maxHearts - 1;
                firstTime = false;
            }
            else
            {
                setFullHealth();
            }
        }
        public void damageLink() {
            
            if (hearts % 1 != 0)
            {
                HUD.ChangeHeart("EmptyHeart", lastHeart);
                firstEmpty = lastHeart;
                lastHeart--;
            } else
            {
                HUD.ChangeHeart("HalfHeart", lastHeart);
            }
            hearts -= halfHeart;
        }
        public void gainHeart()
        {
            if (!IsFullHealth())
            {
                if (hearts % 1 == 0)
                {
                    HUD.ChangeHeart("FullHeart", firstEmpty);
                    firstEmpty = lastHeart;
                    firstEmpty++;
                    hearts += fullHeart;
                }
                else
                {
                    if (hearts == (maxHearts - halfHeart))
                    {
                        HUD.ChangeHeart("FullHeart", lastHeart);
                        hearts += halfHeart;
                    }
                    else
                    {
                        HUD.ChangeHeart("FullHeart", lastHeart);
                        HUD.ChangeHeart("HalfHeart", firstEmpty);
                        firstEmpty++;
                        lastHeart++;
                        hearts += fullHeart;
                    }
                }

            }

        }
        public void setFullHealth() {
            for (int k = 0; k < maxHearts; k++)
            {
                HUD.ChangeHeart("FullHeart", k);
            }
        }

    }
}
