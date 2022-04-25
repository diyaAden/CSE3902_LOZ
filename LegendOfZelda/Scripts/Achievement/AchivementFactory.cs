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
        private string AchivementText;
        public SpriteFont font;
        public string KilledByEnemyText;
        //maybe add sprites?
        private static readonly AchivementFactory instance = new AchivementFactory();
        public static AchivementFactory Instance => instance;

        private AchivementFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            font = content.Load<SpriteFont>("SpriteSheets/General/textFont");
        }

        public void returnSentence(Achievements achievement)
        {
            switch (achievement.AchievementType)
            {
                case AchievementType.KilledByEnemy:
                    AchivementText = "U DEAD :(";
                    break;
                case AchievementType.UseFireKillEnemy:
                    AchivementText = "OMG, Fire!";
                    break;
                case AchievementType.FirstMeetOldMan:
                    AchivementText = "Hi! Old Man.";
                    break;
                case AchievementType.PickUpOneItem:
                    AchivementText = "What is that?";
                    break;
                case AchievementType.GetBackToStart:
                    AchivementText = "IM BACK.";
                    break;
                default:
                    break;

            }


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
