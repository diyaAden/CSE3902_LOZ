using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomManager
    {
        private XmlReader xml;
        public List<Room> Rooms { get; private set; }
        public int CurrentRoom { get; set; }
        public RoomManager() 
        {
            Rooms = new List<Room>();
            CurrentRoom = 1;
        }
        public void LoadContent()
        {
            /* Room 0 is the dev room */
            for (int i = 0; i <= 1; i++) {
                xml = XmlReader.Create("Content\\XML\\Room" + i + ".xml");
                string objectType, objectName;
                int posX, posY;
                Room room = new Room();
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
                    while(xml.Name != "Item") xml.Read();
                    xml.Read();
                    xml.Read();
                    room.AddObject(objectType, objectName, posX, posY);
                }
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