using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks
{
    public interface IBlock : IGameObject
    {
        public Vector2 Position { get; set; }

        public int AdjacentRoom { get; set; }

        public void Disable();

        public void Update();

        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}
