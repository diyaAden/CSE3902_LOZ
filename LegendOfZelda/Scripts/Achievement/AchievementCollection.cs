using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Achievement
{
    public class AchievementCollection
    {
        private List<Achievements> achievementCollection = new List<Achievements>();
        private int currentAchivement = 0;

        public AchievementCollection()
        {
            achievementCollection.Add(AchivementFactory.Instance.KilledByEnemyAchievement());
            achievementCollection.Add(AchivementFactory.Instance.UseFireKillEnemyAchievement());
            achievementCollection.Add(AchivementFactory.Instance.FirstMeetOldManAchievement());
            achievementCollection.Add(AchivementFactory.Instance.PickUpOneItemAchievement());
            achievementCollection.Add(AchivementFactory.Instance.GetBackToStartAchievement());
        }

       
    }
}
