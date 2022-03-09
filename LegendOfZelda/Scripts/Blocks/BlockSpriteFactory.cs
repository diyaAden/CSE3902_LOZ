using LegendOfZelda.Scripts.Blocks.BlockSprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks
{
    class BlockSpriteFactory
    {
        private Texture2D blockSpriteSheet, fireSpriteSheet, wallSpriteSheet, doorSpriteSheet;
        private static readonly BlockSpriteFactory instance = new BlockSpriteFactory(); 
        public static BlockSpriteFactory Instance => instance;

        private BlockSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("SpriteSheets/Blocks/TileSpriteSheet");
            fireSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/FireSpriteSheet");
            doorSpriteSheet = content.Load<Texture2D>("SpriteSheets/General/DungeonTileSet");
            
        }
        public IBlock CreateBlockFromString(string blockName)
        {
            return blockName switch
            {
                //Blocks
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
                "BlackBackground" => CreateBlackBackgroundSprite(),
                //Walls
                "EmptyWallLen" => CreateEmptyWallFullLenSprite(),
                "EmptyWallWidth" => CreateEmptyWallFullWidthSprite(),
                "HalfWallWidth" => CreateEmptyWallHalfWidthSprite(),
                "HalfWallLen" => CreateEmptyWallHalfLenSprite(),
                //Doors
                "BombedDoorUp" => CreateBombedDoorSpriteUp(),
                "BombedDoorDown" => CreateBombedDoorSpriteDown(),
                "BombedDoorLeft" => CreateBombedDoorSpriteLeft(),
                "BombedDoorRight" => CreateBombedDoorSpriteRight(),
                "LockedDoorUp" => CreateLockedDoorSpriteUp(),
                "LockedDoorDown" => CreateLockedDoorSpriteDown(),
                "LockedDoorLeft" => CreateLockedDoorSpriteLeft(),
                "LockedDoorRight" => CreateLockedDoorSpriteRight(),
                "OpenDoorUp" => CreateOpenDoorSpriteUp(),
                "OpenDoorDown" => CreateOpenDoorSpriteDown(),
                "OpenDoorLeft" => CreateOpenDoorSpriteLeft(),
                "OpenDoorRight" => CreateOpenDoorSpriteRight(),
                "CrackedDoorUp" => CreateCrackedDoorSpriteUp(),
                "CrackedDoorDown" => CreateCrackedDoorSpriteDown(),
                "CrackedDoorLeft" => CreateCrackedDoorSpriteLeft(),
                "CrackedDoorRight" => CreateCrackedDoorSpriteRight(),
                _ => null,
            };
        }
        public IBlock CreateFireBlockSprite()
        {
            return new FireBlockSprite(fireSpriteSheet);
        }
        public IBlock CreateBlackBackgroundSprite()
        {
            return new BlackBackgroundSprite(blockSpriteSheet);
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

        public IBlock CreateEmptyWallFullLenSprite()
        {
            return new EmptyWallFullLenSprite(blockSpriteSheet);
        }

        public IBlock CreateEmptyWallFullWidthSprite()
        {
            return new EmptyWallFullWidthSprite(blockSpriteSheet);
        }

        public IBlock CreateEmptyWallHalfWidthSprite()
        {
            return new EmptyWallHalfWidthSprite(blockSpriteSheet);
        }

        public IBlock CreateEmptyWallHalfLenSprite()
        {
            return new EmptyWallHalfLenSprite(blockSpriteSheet);
        }
        public IBlock CreateBombedDoorSpriteUp() {
            return new BombedDoorSpriteUp(doorSpriteSheet);
        }
        public IBlock CreateBombedDoorSpriteDown()
        {
            return new BombedDoorSpriteDown(doorSpriteSheet);
        }
        public IBlock CreateBombedDoorSpriteLeft()
        {
            return new BombedDoorSpriteLeft(doorSpriteSheet);
        }
        public IBlock CreateBombedDoorSpriteRight()
        {
            return new BombedDoorSpriteRight(doorSpriteSheet);
        }
        public IBlock CreateOpenDoorSpriteUp()
        {
            return new OpenDoorSpriteUp(doorSpriteSheet);
        }
        public IBlock CreateOpenDoorSpriteDown()
        {
            return new OpenDoorSpriteDown(doorSpriteSheet);
        }
        public IBlock CreateOpenDoorSpriteLeft()
        {
            return new OpenDoorSpriteLeft(doorSpriteSheet);
        }
        public IBlock CreateOpenDoorSpriteRight()
        {
            return new OpenDoorSpriteRight(doorSpriteSheet);
        }
        public IBlock CreateLockedDoorSpriteUp()
        {
            return new LockedDoorSpriteUp(doorSpriteSheet);
        }
        public IBlock CreateLockedDoorSpriteDown()
        {
            return new LockedDoorSpriteDown(doorSpriteSheet);
        }
        public IBlock CreateLockedDoorSpriteLeft()
        {
            return new LockedDoorSpriteLeft(doorSpriteSheet);
        }
        public IBlock CreateLockedDoorSpriteRight()
        {
            return new LockedDoorSpriteRight(doorSpriteSheet);
        }
        public IBlock CreateCrackedDoorSpriteUp()
        {
            return new CrackedDoorSpriteUp(doorSpriteSheet);
        }
        public IBlock CreateCrackedDoorSpriteDown()
        {
            return new CrackedDoorSpriteDown(doorSpriteSheet);
        }
        public IBlock CreateCrackedDoorSpriteLeft()
        {
            return new CrackedDoorSpriteLeft(doorSpriteSheet);
        }
        public IBlock CreateCrackedDoorSpriteRight()
        {
            return new CrackedDoorSpriteRight(doorSpriteSheet);
        }
    }
}
