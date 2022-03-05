using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items
{
    public interface ICollection
    {
        public void Next();

        public void Previous();

        public void Update();

        public IGameObject GameObject(); //MAYBE a list when xml files store

        public void Draw(SpriteBatch spriteBatch);
    }
}
