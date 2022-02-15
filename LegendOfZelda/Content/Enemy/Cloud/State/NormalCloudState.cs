using LegendOfZelda.Content.Enemy.Cloud.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Cloud.State
{
    class NormalCloudState : BasicCloudState
    {
        public NormalCloudState(ICloud cloud, Vector2 position, ISprite sprite)
        {
            direction = 0;
            this.cloud = cloud;
            this.position = position;
            this.sprite = new NormalCloudSprite(LoadCloud.cloudNormal, position);
        }

    }
}
