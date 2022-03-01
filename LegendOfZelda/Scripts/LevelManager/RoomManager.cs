using CustomDataTypes.RoomDataClasses;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomManager
    {
        private List<RoomData> roomData;
        private RoomCreator roomCreator;
        private int currentRoom;
        public List<Room> Rooms { get; private set; }
        public int CurrentRoom { 
            get { 
                return currentRoom; 
            } 
            set {
                currentRoom = value - 1;
            } 
        }
        public RoomManager() 
        {
            Rooms = new List<Room>();
            roomData = new List<RoomData>();
            roomCreator = new RoomCreator();
            currentRoom = 0;
        }
        public void LoadContent(ContentManager content)
        {
            for (int i = 1; i <= 1; i++) {
                RoomData currentRoomData = content.Load<RoomData>("XML/Room" + i);
                roomData.Add(currentRoomData);
                Room room = new Room();
                roomCreator.InsertRoomObjects(currentRoomData, room);
                Rooms.Add(room);
            }
        }
        public void Update()
        {
            Rooms[currentRoom].Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rooms[currentRoom].Draw(spriteBatch);
        }
    }
}