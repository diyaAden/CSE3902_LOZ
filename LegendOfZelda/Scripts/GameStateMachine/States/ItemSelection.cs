using LegendOfZelda.Scripts.GameStateMachine;
using LegendOfZelda.Scripts.HUDandInventoryManager;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts
{
    public class ItemSelection
    {
        public HUDSprite HUD { get; } = new HUDSprite();
        public InventorySprite invSprite = new InventorySprite();
        private bool paused = false, shiftingScreen = false;
        private int distMoved = 0;
        private Vector2 position;
        private const int shiftSpeed = 2, distToShift = 176;

        public void ShiftHUD(Vector2 shiftDist, int scale)
        {
            position = new Vector2(position.X + shiftDist.X * scale, position.Y + shiftDist.Y * scale);
            HUD.ShiftHUD(shiftDist, scale);
        }
        public ItemSelection(int scale, Vector2 screenOffset) { position = new Vector2(screenOffset.X * scale, 0); }
        public void LoadAllTextures(ContentManager content) { HUD.LoadAllTextures(content); }
        public void GetItemSprites(ILink link) { HUD.getItemSprites(link); }
        public void updateItemCounts(ILink link) { HUD.updateItemCounts(link); }
        public void TogglePause() 
        { 
            shiftingScreen = true;
        }
        public void Update(int scale, Vector2 screenOffset)
        {
            if (shiftingScreen) {
                if (!paused) ShiftHUD(new Vector2(0, shiftSpeed), scale);
                else ShiftHUD(new Vector2(0, -shiftSpeed), scale);
                distMoved += shiftSpeed;
                if (distMoved >= distToShift)
                {
                    shiftingScreen = false;
                    paused = !paused;
                    distMoved = 0;
                    if (paused) GameStateController.Instance.SetGameStateItemSelection();
                    else GameStateController.Instance.SetGameStatePlaying();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 screenOffset)
        {
             //HUD.destRect
              HUD.Draw(spriteBatch, scale, screenOffset);
              //invSprite.Draw(spriteBatch, scale, screenOffset);
        }
    }
}
