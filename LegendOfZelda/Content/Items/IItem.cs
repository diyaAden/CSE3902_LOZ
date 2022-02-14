using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items
{
    public interface IItem
    {
        public int timeLimit { get; }
        public Vector2 position { get; set; }

        public void Update();

        public void Draw(SpriteBatch spriteBatch);
    }
}
