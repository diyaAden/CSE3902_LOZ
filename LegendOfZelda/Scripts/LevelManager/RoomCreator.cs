using CustomDataTypes.RoomDataClasses;
using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
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
                room.Items.Add(ItemSpriteFactory.Instance.CreateItemFromString(item.ObjectName));
                room.Items[^1].position = new Vector2(item.PositionX, item.PositionY);
            }
            foreach (RoomObjectData block in roomData.blocks) {
                room.Blocks.Add(BlockSpriteFactory.Instance.CreateBlockFromString(block.ObjectName));
                room.Blocks[^1].position = new Vector2(block.PositionX, block.PositionY);
            }
            foreach (RoomObjectData enemy in roomData.enemies)
            {
                //room.Enemies.Add(EnemySpriteFactory.Instance.CreateEnemyFromString(enemy.ObjectName));
                //room.Enemies[^1].position = new Vector2(enemy.PositionX, enemy.PositionY);
            }
        }
    }
}
