using LegendOfZelda.Scripts.HUDandInventoryManager;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts
{
    public class ItemSelection
    {
        public Vector2 Position { get; set; }
        public HUDSprite HUD { get; } = new HUDSprite();
        public InventorySprite invSprite = new InventorySprite();

        public ItemSelection(int scale, Vector2 screenOffset) { Position = new Vector2(screenOffset.X * scale, 0); }
        public void LoadAllTextures(ContentManager content) { HUD.LoadAllTextures(content); }
        public void GetItemSprites(ILink link) { HUD.getItemSprites(link); }
        public void Update(int scale, Vector2 screenOffset)
        {

        }
        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 screenOffset)
        {
             //HUD.destRect
              HUD.Draw(spriteBatch, scale, screenOffset);
              invSprite.Draw(spriteBatch, scale, screenOffset);
        }
    }
}
