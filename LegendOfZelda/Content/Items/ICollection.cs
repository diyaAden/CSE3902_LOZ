using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items
{
    interface ICollection
    {
        public void Next();

        public void Previous();

        public void Update();

        public void Draw(SpriteBatch spriteBatch);
    }
}
