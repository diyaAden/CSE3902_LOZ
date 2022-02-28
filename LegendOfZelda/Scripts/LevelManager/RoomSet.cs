using System.Collections.Generic;
using System.Xml;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomSet
    {
        private XmlReader currentRoom;
        public List<Room> Rooms { get; private set; }

        public RoomSet() 
        {
            Rooms = new List<Room>();
        }

        public void LoadContent()
        {
            for (int i = 1; i <= 1; i++) {
                /* When adding new xml, go to its properties and make sure it's set to always copy to output directory */
                Rooms.Add(new Room());
                currentRoom = XmlReader.Create("Content\\XML\\Room" + i + ".xml");
                ProcessRoomXml(i - 1);
            }
        }

        public void ProcessRoomXml(int currentRoomNum)
        {

            //Rooms[currentRoomNum].
        }
    }
}