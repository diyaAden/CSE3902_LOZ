using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class ShardSetWeaponSprite : BasicItem
    {
        private readonly List<IItem> shards;
        
        public ShardSetWeaponSprite(Vector2 position)
        {
            shards = new List<IItem>();
            pos = position;
            timerLimit = 30;
            for (int i = 0; i < 4; i++)
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
