using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    class HUDSpriteFactory
    {
        private Texture2D HUDText;
        private static readonly HUDSpriteFactory instance = new HUDSpriteFactory();
        public static HUDSpriteFactory Instance => instance;
        //internal ICollection H { get; private set; }

        private HUDSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            HUDText = content.Load<Texture2D>("SpriteSheets/General/HUDText");
        }
        public IHUDItem CreateHUDItemFromString(string name)
        {
            return name switch
            {
                "HeartItem" => CreateFullHeart(),
                "HalfHeartItem" => CreateHalfHeart(),
                "EmptyHeartItem" => CreateEmptyHeart(),
                _ => null,
            };
        }

        public IHUDItem CreateFullHeart()
        {
            return new HeartItem(HUDText);
        }
        public IHUDItem CreateHalfHeart()
        {
            return new HalfHeartItem(HUDText);
        }
        public IHUDItem CreateEmptyHeart()
        {
            return new EmptyHeartItem(HUDText);
        }

    }
}
