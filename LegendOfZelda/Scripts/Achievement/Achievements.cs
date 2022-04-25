using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        public AchievementType AchievementType { get { return achievementType; } set { achievementType = value; } }
        private AchievementType achievementType;
        public Boolean IsGainedAchievement { get { return isGainedAchievement; } set { isGainedAchievement = value; } }

        private Boolean isGainedAchievement;
        private string AchivementText;
        private Vector2 pos = new Vector2(20, 10);
        private int remainTimer = 0;
        private int remainTimerLimit = 100;
        public Achievements(AchievementType achievementType)
        {
            this.achievementType = achievementType;
            isGainedAchievement = false;
            AchivementText = "test";
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

        public void Update()
        {
            if (remainTimer <= remainTimerLimit)
            {
                remainTimer++;
                if (isGainedAchievement == false)
                {
                    returnSentence(this);
                }
                isGainedAchievement = true;
                
            }
            else
            {
                AchivementText = "test";
            }
        }

        public void Draw(SpriteBatch spriteBatch, int scale, SpriteFont font)
        {
            spriteBatch.DrawString(font, AchivementText, pos, Color.Red);
        }
    }

}
