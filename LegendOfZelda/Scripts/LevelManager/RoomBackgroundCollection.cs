using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    class RoomBackgroundCollection : ICollection
    {
        private readonly List<IRoomBackground> RoomCollection = new List<IRoomBackground>();
        private int currentObject = 0;

        public RoomBackgroundCollection()
        {
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateDevRoom());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomOne());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomTwo());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomThree());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomFour());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomFive());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomSix());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomSeven());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomEight());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomNine());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomTen());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomEleven());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomTwelve());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomThirteen());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomFourteen());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomFifteen());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomSixteen());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomSeventeen());
            RoomCollection.Add(RoomBackgroundFactory.Instance.CreateRoomEighteen());
        }

        public void Next()
        {
            currentObject = ++currentObject % RoomCollection.Count;
        }

        public void Previous()
        {
            if (--currentObject < 0) { currentObject = RoomCollection.Count - 1; }
        }

        public void Update()
        {
            RoomCollection[currentObject].Update();
        }

        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            RoomCollection[currentObject].Draw(spriteBatch, scale);
        }
    }
}