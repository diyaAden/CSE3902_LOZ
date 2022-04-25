using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        public List<IHUDItem> Hearts { get; set; }
        private bool firstTime = true;

        public HealthManager(HUDSprite HUDG)
        {
            HUD = HUDG;
            Hearts = new List<IHUDItem>();
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
                    Hearts.Add(HUDSpriteFactory.Instance.CreateHUDItemFromString("HeartItem"));
                    Hearts[^1].Position = new Vector2(HeartposX, HeartposY);
                    Hearts[^1].name = "HeartItem";
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
        public void damageLink()
        {

            hearts -= halfHeart;
        }
        public void gainHeart()
        {
            if (!IsFullHealth())
            {
                hearts += fullHeart;
            }

        }
        public void setFullHealth()
        {
            hearts = maxHearts;
        }
        public void Update()
        {
            if (hearts > 4) hearts = 4;
            

            bool isHalfHeart = false;
            if(hearts % 1 != 0)
            {
                isHalfHeart = true;
                hearts -= 0.5f;
            }

            foreach (IHUDItem Heart in Hearts) Heart.Update();
            HeartposX = 179;
            HeartposY = 36;
            int k;
            for (k = 0; k < maxHearts; k++)
            {
                if(k < hearts)
                {
                    Hearts[k] = HUDSpriteFactory.Instance.CreateHUDItemFromString("HeartItem");
                    Hearts[k].Position = new Vector2(HeartposX, HeartposY);
                }else if(k == hearts && isHalfHeart)
                {
                    Hearts[(int)hearts] = HUDSpriteFactory.Instance.CreateHUDItemFromString("HalfHeartItem");
                    Hearts[(int)hearts].Position = new Vector2(HeartposX, HeartposY);
                }
                else
                {
                    Hearts[k] = HUDSpriteFactory.Instance.CreateHUDItemFromString("EmptyHeartItem");
                    Hearts[k].Position = new Vector2(HeartposX, HeartposY);
                }
                if (!((k + 1) == maxHearts))
                    HeartposX += 8;
            }
            if (isHalfHeart)
            {

                hearts += 0.5f;
            }
        }
        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {
            foreach (IHUDItem Heart in Hearts)
            {
                Heart.Draw(spriteBatch, scale, offset);
            }
        }
    }
}
