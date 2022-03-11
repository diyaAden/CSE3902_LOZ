using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items
{
    public interface IItem : IGameObject
    {
        public int TimeLimit { get; }
        public int AnimationTimer { get; set; }
        public Vector2 Position { get; set; }

        public string Name { get; set; }

        public void Update();

        public void Update(Vector2 linkPosition);

        public void PickItem(Vector2 linkPosition);

        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}
