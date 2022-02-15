using LegendOfZelda.Content.Enemy.WallMaster.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.WallMaster.State
{
    class IdleWallMasterState : BasicWallMasterState
    {
        public IdleWallMasterState(IWallMaster trap, Vector2 position, ISprite sprite)
        {
            direction = 0;
            this.wallMaster = wallMaster;
            this.position = position;
            this.sprite = new IdleWallMasterSprite(LoadWallMaster.wallMasterIdle, position);
        }

    }
}
