using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Achievement
{
    public enum AchievementType
    {
        KilledByEnemy, //player health 
        UseFireKillEnemy, //enemy health, player weapon
        FirstMeetOldMan, //player, room
        PickUpOneItem, //player, item
        GetBackToStart //hand, player, room
    }
    public class Achievements
    {
        public AchievementType AchievementType { get { return achievementType; } set{ achievementType = value; } }
        private AchievementType achievementType;
        public Boolean IsGainedAchievement { get { return isGainedAchievement; } set { isGainedAchievement = value; } }
        
        private Boolean isGainedAchievement;
        public Achievements(AchievementType achievementType)
        {
            this.achievementType = achievementType;
            isGainedAchievement = false;
        }
    }
}
