using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items
{
    public interface IItem: IGameObject
    {
        public int TimeLimit { get; }
        public Vector2 Position { get; set; }

        public void Update();

        public void Update(Vector2 linkPosition);


        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}
