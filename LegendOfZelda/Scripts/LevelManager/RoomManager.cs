using LegendOfZelda.Scripts.LevelManager.RoomDataClasses;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomManager
    {
        private readonly RoomCreator roomCreator;
        private XmlReader xml;
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
            for (int i = 0; i <= 0; i++) {
                xml = XmlReader.Create("Content\\XML\\Room0.xml");

                xml.MoveToContent();
                string data = xml.ReadElementContentAsString();

                System.Console.WriteLine(data);

                Room room = new Room();
                //roomCreator.InsertRoomObjects(currentRoomData, room);
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