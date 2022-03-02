using LegendOfZelda.Scripts.Blocks.BlockSprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    class RoomBackgroundFactory
    {
        private Texture2D DungeonTiles;
        private static readonly RoomBackgroundFactory instance = new RoomBackgroundFactory();
        public static RoomBackgroundFactory Instance => instance;

        private RoomBackgroundFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            DungeonTiles = content.Load<Texture2D>("SpriteSheets/General/DungeonTileSet");
        }
        
        public IRoomBackground CreateDevRoom()
        {
            return new Room0Sprite(DungeonTiles);
        }
        
    }
}
