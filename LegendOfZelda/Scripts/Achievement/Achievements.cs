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
        BombHurtEnemy, //enemy health, player weapon
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
        private Vector2 pos = new Vector2(12, 450);
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
                    AchivementText = "U DEAD :(";    // When dead
                    break;
                case AchievementType.BombHurtEnemy:  //Use bomb hurt enemy
                    AchivementText = "OMG, BOMB!";
                    break;
                case AchievementType.FirstMeetOldMan: //First come old man room
                    AchivementText = "Hi! Old Man.";
                    break;
                case AchievementType.PickUpOneItem:  //first pick up item
                    AchivementText = "What is that?";
                    break;
                case AchievementType.GetBackToStart: //go back first room since wall monster
                    AchivementText = "OK, IM BACK.";
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
