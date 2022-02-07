using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items
{
    public class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("SpriteSheets/itemSpriteSheet");
        }

        //public ISprite CreateCompassSprite

        //public ISprite CreateMapSprite

        //public ISprite CreateKeySprite

        //public ISprite CreateHeartContainerSprite

        //public ISprite CreateTriforcePieceSprite

        //public ISprite CreateWoodBoonerangSprite

        //public ISprite CreateBowSprite

        //public ISprite CreateHeartSprite

        //public ISprite CreateRupeeSprite

        //public ISprite CreateArrowSprite

        //public ISprite CreateBombSprite

        //public ISprite CreateFairySprite

        //public ISprite CreateClockSprite

        //Other sprites may be necessary
    }
}
