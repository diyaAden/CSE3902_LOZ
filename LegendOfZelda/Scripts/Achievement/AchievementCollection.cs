using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Achievement
{
    public class AchievementCollection
    {
        private List<Achievements> achievementCollection = new List<Achievements>();
        private int currentAchivement = 0;
        public SpriteFont font;
        public AchievementCollection()
        {
            achievementCollection.Add(AchivementFactory.Instance.KilledByEnemyAchievement());
            achievementCollection.Add(AchivementFactory.Instance.UseFireKillEnemyAchievement());
            achievementCollection.Add(AchivementFactory.Instance.FirstMeetOldManAchievement());
            achievementCollection.Add(AchivementFactory.Instance.PickUpOneItemAchievement());
            achievementCollection.Add(AchivementFactory.Instance.GetBackToStartAchievement());
        }
        public void LoadAllTextures(ContentManager content)
        {
            font = content.Load<SpriteFont>("SpriteSheets/General/textFont");
        }
        public void Update() {
            achievementCollection[currentAchivement].Update();
        }
        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            achievementCollection[currentAchivement].Draw(spriteBatch, scale, font);
        }
    }
}
