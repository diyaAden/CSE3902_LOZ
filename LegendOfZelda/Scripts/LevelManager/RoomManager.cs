using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomManager
    {
        private XmlReader xml;
        public List<ILevel> Rooms { get; set; }
        public int CurrentRoom { get; set; }
        public RoomManager()
        {
        }
        public void LoadContent(int scale)
        {
            CurrentRoom = 9;
            Rooms = new List<ILevel>();
            /* Room 0 is the dev room */
            for (int i = 0; i <= 18; i++) {
                xml = XmlReader.Create("Scripts/LevelManager/XMLFiles/Room" + i + ".xml");
                string objectType, objectName;
                int posX, posY, adjacentRoom;
                adjacentRoom = -1;
                ILevel room = new Room();
                xml.MoveToContent();
                xml.Read();
                while (xml.IsStartElement()) {
                    while (xml.Name != "ObjectType") xml.Read();
                    objectType = xml.ReadElementContentAsString();
                    while (xml.Name != "ObjectName") xml.Read();
                    objectName = xml.ReadElementContentAsString();
                    while (xml.Name != "PositionX") xml.Read();
                    posX = xml.ReadElementContentAsInt() * scale;
                    while (xml.Name != "PositionY") xml.Read();
                    posY = xml.ReadElementContentAsInt() * scale;
                    if (objectName.Contains("Door"))
                    {
                        while (xml.Name != "roomNumber") xml.Read();
                        adjacentRoom = xml.ReadElementContentAsInt();
                    }
                    while (xml.Name != "Item") xml.Read();
                    xml.Read();
                    xml.Read();
                    room.AddObject(objectType, objectName, posX, posY, adjacentRoom);
                }
                room.AddRoomBackground(i);
                Rooms.Add(room);
            }
        }
        public void NextRoom()
        {
            CurrentRoom = ++CurrentRoom % Rooms.Count;
        }
        public void PreviousRoom()
        {
            CurrentRoom--;
            CurrentRoom = (CurrentRoom + Rooms.Count) % Rooms.Count;
        }
        public void Update(int scale)
        {
            if (CurrentRoom  < 0)
                CurrentRoom += Rooms.Count;
            CurrentRoom %= Rooms.Count;
            Rooms[CurrentRoom].Update(scale);
        }
        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rooms[CurrentRoom].Draw(spriteBatch, scale);
        }
    }
}