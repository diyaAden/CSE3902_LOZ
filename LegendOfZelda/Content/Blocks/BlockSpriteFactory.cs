using LegendOfZelda.Content.Blocks.BlockSprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Blocks
{
    class BlockSpriteFactory
    {
        private Texture2D blockSpriteSheet;
        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private BlockSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("SpriteSheets/Blocks/TileSpriteSheet");
        }
        public IBlock CreateBlueFloorSprite()
        {
            return new BlueFloorSprite(blockSpriteSheet);
        }
        public IBlock CreateBlueSandSprite()
        {
            return new BlueSandSprite(blockSpriteSheet);
        }
        public IBlock CreateStatueLeftSprite()
        {
            return new StatueLeftSprite(blockSpriteSheet);
        }
        public IBlock CreateStatueRightSprite()
        {
            return new StatueRightSprite(blockSpriteSheet);
        }
        public IBlock CreateStairsSprite()
        {
            return new StairsSprite(blockSpriteSheet);
        }
        public IBlock CreateLadderSprite()
        {
            return new LadderSprite(blockSpriteSheet);
        }
        public IBlock CreateSquareBlockSprite()
        {
            return new SquareBlockSprite(blockSpriteSheet);
        }
        public IBlock CreatePushBlockSprite()
        {
            return new PushBlockSprite(blockSpriteSheet);
        }
        public IBlock CreateWhiteBrickSprite()
        {
            return new WhiteBrickSprite(blockSpriteSheet);
        }
        public IBlock CreateBlueGapSprite()
        {
            return new BlueGapSprite(blockSpriteSheet);
        }
    }
}
