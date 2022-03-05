using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks
{
    public interface IBlock
    {
        public Vector2 position { get; set; }

        public void Update();

        public void Draw(SpriteBatch spriteBatch);
    }
}
