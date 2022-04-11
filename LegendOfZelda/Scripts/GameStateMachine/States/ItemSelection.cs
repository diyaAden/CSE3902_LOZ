using LegendOfZelda.Scripts.GameStateMachine.States;
using LegendOfZelda.Scripts.HUDandInventoryManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts
{
    class ItemSelection
    {
        public Vector2 position = new Vector2(0,0);

        public HUDSprite HUD = new HUDSprite();
        public InventorySprite invSprite = new InventorySprite();
        public Vector2 offset = new Vector2(0, 0);
        public ItemSelection()
        {

        }


        public void Update(int scale, Vector2 screenOffset)
        {

        }


        public void Draw(SpriteBatch spriteBatch, int scale)
        {
             //HUD.destRect
              //HUD.Position
              HUD.Draw(spriteBatch, 2, offset);
              invSprite.Draw(spriteBatch, 2, offset);
        }

    
    }
}
