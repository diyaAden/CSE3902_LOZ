using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items
{
    public interface ICollection
    {
        public void Next();

        public void Previous();

        public void Update(int scale);

        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}
