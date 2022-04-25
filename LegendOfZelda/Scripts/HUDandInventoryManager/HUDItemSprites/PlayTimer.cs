using LegendOfZelda.Scripts.PlayerStats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.HUDandInventoryManager.HUDItemSprites
{
    public class PlayTimer
    {




        public void Draw(SpriteBatch _spriteBatch,SpriteFont _spriteFont, int currentTime, PlayerStat pstat)
        {
            _spriteBatch.DrawString(_spriteFont, "Par Time: " + pstat.TimeToBeat, new Vector2(8, 5), Color.White);
            _spriteBatch.DrawString(_spriteFont, "Best Time: " + pstat.BestTime, new Vector2(8, 30), Color.White);
            _spriteBatch.DrawString(_spriteFont, "Current Time: " + currentTime / 60, new Vector2(8, 55), Color.White);

        }
        


    }
}
