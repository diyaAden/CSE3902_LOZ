using CustomDataTypes.RoomDataClasses;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Scripts.LevelManager
{
    class RoomCreator
    {
        public RoomCreator() { }
        public void InsertRoomObjects(RoomData roomData, Room room)
        {
            foreach (RoomObjectData item in roomData.items) {
                room.Items.Add(ItemSpriteFactory.Instance.CreateItem(item.ObjectName));
                room.Items[room.Items.Count - 1].position = new Vector2(item.PositionX, item.PositionY);
            }
        }
    }
}
