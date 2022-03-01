using CustomDataTypes.RoomDataClasses;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomManager
    {
        private readonly RoomCreator roomCreator;
        public List<Room> Rooms { get; private set; }
        public int CurrentRoom { get; set; }
        public RoomManager() 
        {
            Rooms = new List<Room>();
            roomCreator = new RoomCreator();
            CurrentRoom = 0;
        }
        public void LoadContent(ContentManager content)
        {
            /* Room 0 is the dev room */
            for (int i = 0; i <= 1; i++) {
                RoomData currentRoomData = content.Load<RoomData>("XML/Room" + i);
                Room room = new Room();
                roomCreator.InsertRoomObjects(currentRoomData, room);
                Rooms.Add(room);
            }
        }
        public void Update()
        {
            Rooms[CurrentRoom].Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rooms[CurrentRoom].Draw(spriteBatch);
        }
    }
}