using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomManager
    {
        private const int roomsToLoad = 20;
        private readonly List<int> roomsToSpawnKey = new List<int>() { 1, 3, 6, 13, 18 };
        private readonly List<int> roomsToSpawnHeartContainer = new List<int>() { 14 };
        private readonly List<int> roomsToSpawnBoomerang = new List<int>() { 11 };
        private readonly List<int> roomsToOpenDoorsEnemies = new List<int>() { 4, 5, 14 };
        private readonly List<int> roomsToOpenDoorsBlocks = new List<int>() { 9 };
        private XmlReader xml;
        private bool secretPath6To10Open = false, secretPath7To11Open = false;
        public List<ILevel> Rooms { get; set; }
        public int CurrentRoom { get; set; }
        public bool SecretPath6To10Open
        {
            get { return secretPath6To10Open; }
            set
            {
                secretPath6To10Open = value;
                if (secretPath6To10Open)
                {
                    Rooms[6].OpenSecretDoor(RoomObjectEditor.Direction.UP);
                    Rooms[10].OpenSecretDoor(RoomObjectEditor.Direction.DOWN);
                }
            }
        }
        public bool SecretPath7To11Open
        {
            get { return secretPath7To11Open; }
            set
            {
                secretPath7To11Open = value;
                if (secretPath7To11Open)
                {
                    Rooms[7].OpenSecretDoor(RoomObjectEditor.Direction.UP);
                    Rooms[11].OpenSecretDoor(RoomObjectEditor.Direction.DOWN);
                }
            }
        }
        public RoomManager() { }

        public void LoadContent(int scale, Vector2 screenOffset)
        {
            CurrentRoom = 2;
            Rooms = new List<ILevel>();
            /* Room 0 is the dev room */
            for (int i = 0; i <= roomsToLoad; i++) {
                xml = XmlReader.Create("Scripts/LevelManager/XMLFiles/Room" + i + ".xml");
                string objectType, objectName;
                int posX, posY, adjacentRoom = -1;
                ILevel room = new Room();
                xml.MoveToContent();
                xml.Read();
                while (xml.IsStartElement()) {
                    while (xml.Name != "ObjectType") xml.Read();
                    objectType = xml.ReadElementContentAsString();
                    while (xml.Name != "ObjectName") xml.Read();
                    objectName = xml.ReadElementContentAsString();
                    while (xml.Name != "PositionX") xml.Read();
                    posX = (xml.ReadElementContentAsInt() + (int)screenOffset.X) * scale;
                    while (xml.Name != "PositionY") xml.Read();
                    posY = (xml.ReadElementContentAsInt() + (int)screenOffset.Y) * scale;
                    if (objectName.Contains("Door") || objectName.Contains("Stairs"))
                    {
                        while (xml.Name != "roomNumber") xml.Read();
                        adjacentRoom = xml.ReadElementContentAsInt();
                    }
                    while (xml.Name != "Item") xml.Read();
                    xml.Read();
                    xml.Read();
                    room.AddObject(objectType, objectName, posX, posY, adjacentRoom);
                }
                room.AddRoomBackground(i, screenOffset, scale);
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
        public void Update(Vector2 linkPosition, int scale, Vector2 screenOffset, bool hasClock)
        {
            Rooms[CurrentRoom].Update(linkPosition, scale, screenOffset, hasClock);
            RoomEvents(scale, screenOffset);
        }
        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rooms[CurrentRoom].Draw(spriteBatch, scale);
        }
        private void RoomEvents(int scale, Vector2 screenOffset)
        {
            if (roomsToSpawnKey.Contains(CurrentRoom) && Rooms[CurrentRoom].Enemies.Count == 0)
                Rooms[CurrentRoom].SpawnKey();
            if (roomsToSpawnHeartContainer.Contains(CurrentRoom) && Rooms[CurrentRoom].Enemies.Count == 0)
                Rooms[CurrentRoom].SpawnHeartContainer(scale, screenOffset);
            if (roomsToSpawnBoomerang.Contains(CurrentRoom) && Rooms[CurrentRoom].Enemies.Count == 0)
                Rooms[CurrentRoom].SpawnBoomerang(scale, screenOffset);
            if (roomsToOpenDoorsEnemies.Contains(CurrentRoom) && Rooms[CurrentRoom].Enemies.Count == 0)
                Rooms[CurrentRoom].OpenCrackedDoors();
            if (roomsToOpenDoorsBlocks.Contains(CurrentRoom))
                Rooms[CurrentRoom].DetectPushBlockMovement();
        }
    }
}