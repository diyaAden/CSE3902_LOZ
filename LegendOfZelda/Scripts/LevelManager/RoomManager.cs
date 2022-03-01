using CustomDataTypes;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomManager
    {
        public List<Room> Rooms { get; private set; }
        private List<RoomData> roomData;
        public RoomManager() 
        {
            Rooms = new List<Room>();
            roomData = new List<RoomData>();
        }
        public void LoadContent(ContentManager content)
        {
            for (int i = 1; i <= 1; i++) {
                RoomData room = content.Load<RoomData>("XML/Room" + i);
                roomData.Add(room);
                System.Diagnostics.Debug.WriteLine(room.items[0].ObjectType);
                System.Diagnostics.Debug.WriteLine(room.items[0].ObjectName);
                System.Diagnostics.Debug.WriteLine(room.items[0].PositionX);
                System.Diagnostics.Debug.WriteLine(room.items[0].PositionY);
            }
        }
    }
}