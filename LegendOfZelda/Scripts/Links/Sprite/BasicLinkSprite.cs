using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Links.Sprite
{
    abstract class BasicLinkSprite: ISprite
    {
        protected virtual Vector2 Pos { get; set; }
        public virtual Vector2 Position
        {
            get { return new Vector2(Pos.X, Pos.Y); }
            set { Pos = value; }
        }
        public virtual Texture2D Texture { get; set; }

        protected virtual int Rows { get; set; }
        protected virtual int Columns { get; set; }
        protected virtual int CurrentFrame { get; set; }
        protected virtual int TotalFrames { get; set; }

        protected virtual int Timer { get; set; }

        public int LinkMoveSpeed
        {
            get { return linkMoveSpeed; }
            set { linkMoveSpeed = value; }
        }

        protected int linkMoveSpeed = 2;

        //set to false by default, change to true when "e" key is pressed. 
        public bool checkDamageState = true; //{ get; set; }
        public Color SpriteColor { get; set; }

        protected int width;
        protected int height;
        protected int row;
        protected int column;

        public virtual void Update()
        {

        }

        private void GetBoxSize()
        {
            width = Texture.Width / Columns;
            height = Texture.Height / Rows;
            row = CurrentFrame / Columns;
            column = CurrentFrame % Columns;
        }
        public virtual Rectangle LinkBox(int scale)
        {
            GetBoxSize();
            return new Rectangle((int)Pos.X, (int)Pos.Y, width * scale, height * scale);
        }
        public virtual void Draw(SpriteBatch spriteBatch, int scale)
        {
            GetBoxSize();

            if (checkDamageState == true)
            {
                SpriteColor = Color.Red;
            }
            else
            {
                SpriteColor = Color.White;
            }

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = LinkBox(scale);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, SpriteColor);

        }
    }
}

