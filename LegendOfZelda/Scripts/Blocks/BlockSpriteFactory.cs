using LegendOfZelda.Scripts.Blocks.BlockSprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks
{
    class BlockSpriteFactory
    {
        private Texture2D blockSpriteSheet, fireSpriteSheet;
        private static readonly BlockSpriteFactory instance = new BlockSpriteFactory();
        public static BlockSpriteFactory Instance => instance;

        private BlockSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("SpriteSheets/Blocks/TileSpriteSheet");
            fireSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/FireSpriteSheet");
        }
        public IBlock CreateBlockFromString(string blockName)
        {
            return blockName switch
            {
                "Fire" => CreateFireBlockSprite(),
                "BlueFloor" => CreateBlueFloorSprite(),
                "BlueSand" => CreateBlueSandSprite(),
                "StatueLeft" => CreateStatueLeftSprite(),
                "StatueRight" => CreateStatueRightSprite(),
                "Stairs" => CreateStairsSprite(),
                "Ladder" => CreateLadderSprite(),
                "SquareBlock" => CreateSquareBlockSprite(),
                "PushBlock" => CreatePushBlockSprite(),
                "WhiteBrick" => CreateWhiteBrickSprite(),
                "BlueGap" => CreateBlueGapSprite(),
                _ => null,
            };
        }
        public IBlock CreateFireBlockSprite()
        {
            return new FireBlockSprite(fireSpriteSheet);
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
