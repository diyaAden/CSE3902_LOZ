using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomManager
    {
        private XmlReader xml;
        private List<ILevel> Rooms { get; set; }
        public int CurrentRoom { get; set; }
        public RoomManager()
        {
            CurrentRoom = 0;
        }
        public void LoadContent()
        {
            Rooms = new List<ILevel>();
            /* Room 0 is the dev room */
            for (int i = 0; i <= 18; i++) {
                xml = XmlReader.Create("Scripts/LevelManager/XMLFiles/Room" + i + ".xml");
                string objectType, objectName;
                int posX, posY;
                ILevel room = new Room();
                xml.MoveToContent();
                xml.Read();
                while (xml.IsStartElement()) {
                    while (xml.Name != "ObjectType") xml.Read();
                    objectType = xml.ReadElementContentAsString();
                    while (xml.Name != "ObjectName") xml.Read();
                    objectName = xml.ReadElementContentAsString();
                    while (xml.Name != "PositionX") xml.Read();
                    posX = xml.ReadElementContentAsInt();
                    while (xml.Name != "PositionY") xml.Read();
                    posY = xml.ReadElementContentAsInt();
                    while (xml.Name != "Item") xml.Read();
                    xml.Read();
                    xml.Read();
                    room.AddObject(objectType, objectName, posX, posY);
                }
                room.AddRoomBackground(i);
                Rooms.Add(room);
            }
        }
        public void Update()
        {
            if (CurrentRoom  < 0)
                CurrentRoom += Rooms.Count;
            CurrentRoom %= Rooms.Count;
            Rooms[CurrentRoom].Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rooms[CurrentRoom].Draw(spriteBatch);
        }
    }
}