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
        KilledByEnemy, //game over
        BombHurtEnemy, //player weapon
        FirstMeetOldMan, //player, room
        PickUpOneItem, //player, item
        GetBackToStart, //hand, player
        WinDungeon, //dungeon health
        Win, //win the game
        WinInSeconds, //win the game in some seconds
        HurtByGel, //link, gel
        BombDoor //bomb, door

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
                    AchivementText = "U DEAD :(";    // When dead, 0
                    break;
                case AchievementType.BombHurtEnemy:  //Use bomb hurt enemy, 1
                    AchivementText = "OMG, BOMB!";
                    break;
                case AchievementType.FirstMeetOldMan: //First come old man room, 2
                    AchivementText = "Hi! Old Man.";
                    break;
                case AchievementType.PickUpOneItem:  //first pick up item, 3
                    AchivementText = "What is that?";
                    break;
                case AchievementType.GetBackToStart: //go back first room since wall monster, 4
                    AchivementText = "OK, IM BACK.";
                    break;
                case AchievementType.WinDungeon: //win the dungeon, 5
                    AchivementText = "An easy fight";
                    break;
                case AchievementType.Win: //win the game, 6
                    AchivementText = "U got it!!";
                    break;
                case AchievementType.WinInSeconds: //win the game in certain seconds, 7
                    AchivementText = "SUPERMAN";
                    break;
                case AchievementType.HurtByGel: //hurt by gel, 8
                    AchivementText = "Soft but Dangerous";
                    break;
                case AchievementType.BombDoor: //use bomb to get door, 9
                    AchivementText = "keen intuition";
                    break;

                default:
                    break;

            }
        }

        public void checkAndChangeText()
        {
            if (isGainedAchievement == false)
            {
                returnSentence(this);
                isGainedAchievement = true;
            }

        }

        public void Update()
        {
            if (remainTimer <= remainTimerLimit)
            {
                remainTimer++;
            }
            else
            {
                AchivementText = "test";
            }
        }

        public void Draw(SpriteBatch spriteBatch, int scale, SpriteFont font)
        {
            spriteBatch.DrawString(font, AchivementText, pos, Color.White);
        }
    }

}
