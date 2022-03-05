using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items
{
    public interface IItem: IGameObject
    {
        public int timeLimit { get; }
        public Vector2 position { get; set; }

        public void Update();

        public void Update(Vector2 linkPosition);


        public void Draw(SpriteBatch spriteBatch);
    }
}
