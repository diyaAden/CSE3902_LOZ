using System.Collections.Generic;
using LegendOfZelda.Scripts.Blocks.BlockSprites;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    class RoomBackgroundFactory
    {
        private Texture2D DungeonTiles;
        private static readonly RoomBackgroundFactory instance = new RoomBackgroundFactory();
        public static RoomBackgroundFactory Instance => instance;
        internal ICollection RoomCollection { get; private set; }

        private RoomBackgroundFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            DungeonTiles = content.Load<Texture2D>("SpriteSheets/General/DungeonMap");
        }
        public IRoomBackground CreateFromRoomNumber(int roomNumber) {
            return roomNumber switch
            {
                0 => CreateDevRoom(),
                1 => CreateRoomOne(),
                2 => CreateRoomTwo(),
                3 => CreateRoomThree(),
                4 => CreateRoomFour(),
                5 => CreateRoomFive(),
                6 => CreateRoomSix(),
                7 => CreateRoomSeven(),
                8 => CreateRoomEight(),
                9 => CreateRoomNine(),
                10 => CreateRoomTen(),
                11 => CreateRoomEleven(),
                12 => CreateRoomTwelve(),
                13 => CreateRoomThirteen(),
                14 => CreateRoomFourteen(),
                15 => CreateRoomFifteen(),
                16 => CreateRoomSixteen(),
                17 => CreateRoomSeventeen(),
                18 => CreateRoomEighteen(),
                _ => null,
            };
        }


        public IRoomBackground CreateDevRoom()
        {
            return new Room0Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomOne()
        {
            return new Room1Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomTwo()
        {
            return new Room2Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomThree()
        {
            return new Room3Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomFour()
        {
            return new Room4Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomFive()
        {
            return new Room5Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomSix()
        {
            return new Room6Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomSeven()
        {
            return new Room7Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomEight()
        {
            return new Room8Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomNine()
        {
            return new Room9Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomTen()
        {
            return new Room10Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomEleven()
        {
            return new Room11Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomTwelve()
        {
            return new Room12Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomThirteen()
        {
            return new Room13Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomFourteen()
        {
            return new Room14Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomFifteen()
        {
            return new Room15Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomSixteen()
        {
            return new Room16Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomSeventeen()
        {
            return new Room17Sprite(DungeonTiles);
        }
        public IRoomBackground CreateRoomEighteen()
        {
            return new Room18Sprite(DungeonTiles);
        }
    }
}
