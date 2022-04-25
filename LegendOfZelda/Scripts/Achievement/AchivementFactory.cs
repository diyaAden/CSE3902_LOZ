using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Achievement
{
    public class AchivementFactory
    {
        
        //maybe add sprites?
        private static readonly AchivementFactory instance = new AchivementFactory();
        public static AchivementFactory Instance => instance;

        private AchivementFactory()
        {

        }

      


        public Achievements KilledByEnemyAchievement()
        {
            return new Achievements(AchievementType.KilledByEnemy);
        }


        public Achievements UseFireKillEnemyAchievement()
        {
            return new Achievements(AchievementType.UseFireKillEnemy);
        }


        public Achievements FirstMeetOldManAchievement()
        {
            return new Achievements(AchievementType.FirstMeetOldMan);
        }


        public Achievements PickUpOneItemAchievement()
        {
            return new Achievements(AchievementType.PickUpOneItem);
        }


        public Achievements GetBackToStartAchievement()
        {
            return new Achievements(AchievementType.GetBackToStart);
        }


    }
}
