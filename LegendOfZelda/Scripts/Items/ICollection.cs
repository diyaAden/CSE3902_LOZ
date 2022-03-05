using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items
{
    interface ICollection
    {
        public void Next();

        public void Previous();

        public void Update();

        public void Draw(SpriteBatch spriteBatch);
    }
}
