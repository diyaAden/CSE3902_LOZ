using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class MapRoomLocations
    {
        
        public enum Rooms {
            Room1,
            Room2,
            Room3,
            Room4,
            Room5,
            Room6,
            Room7,
            Room8,
            Room9,
            Room10,
            Room11,
            Room12,
            Room13,
            Room14,
            Room15,
            Room16,
            Room17
        }

        public Vector2 RoomLocation(int room)
        {
            Vector2 location;
            switch (room)
            {
                case 0:
                    location = new Vector2(120, 50);
                    break;
                case 1:
                    location = new Vector2(120, 50);
                    break;
                case 2:
                    location = new Vector2(128, 50);
                    break;
                case 3:
                    location = new Vector2(135, 50);
                    break;
                case 4:
                    location = new Vector2(128, 43);
                    break;
                case 5:
                    location = new Vector2(120, 40);
                    break;
                case 6:
                    location = new Vector2(128, 40);
                    break;
                case 7:
                    location = new Vector2(135, 40);
                    break;
                case 8:
                    location = new Vector2(113, 36);
                    break;
                case 9:
                    location = new Vector2(120, 36);
                    break;
                case 10:
                    location = new Vector2(128, 36);
                    break;
                case 11:
                    location = new Vector2(135, 36);
                    break;
                case 12:
                    location = new Vector2(142, 36);
                    break;
                case 13:
                    location = new Vector2(128, 32);
                    break;
                case 14:
                    location = new Vector2(144, 32);
                    break;
                case 15:
                    location = new Vector2(153, 32);
                    break;
                case 16:
                    location = new Vector2(120, 27);
                    break;
                case 17:
                    location = new Vector2(128, 27);
                    break;
                case 18:
                    location = new Vector2(128, 27);
                    break;
                default:
                    location = new Vector2(0, 0);
                    break;
            }
            return location;
        }

    }
}
