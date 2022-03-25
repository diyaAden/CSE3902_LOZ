using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class ShardSetWeaponSprite : BasicItem
    {
        private readonly List<IItem> shards;
        private const int shardsToSpawn = 4, itemTimeLimit = 30;
        
        public ShardSetWeaponSprite(Vector2 position)
        {
            shards = new List<IItem>();
            pos = position;
            timerLimit = itemTimeLimit;
            for (int i = 0; i < shardsToSpawn; i++)
            {
                shards.Add(WeaponSpriteFactory.Instance.CreateSwordShardWeaponSprite(i));
                shards[i].Position = pos;
            }
        }

        public override void Update()
        {
            foreach (IItem shard in shards)
            {
                shard.Update();
            }
        }
        public override Rectangle ObjectBox(int scale)
        {
            return new Rectangle();
        }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            foreach (IItem shard in shards)
            {
                shard.Draw(spriteBatch, scale);
            }
        }
    }
}
