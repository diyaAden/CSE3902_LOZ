using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class SecretWallLeftSprite : BasicBlock
    {
        private const int xPos = 815, yPos = 44, width = 32, height = 32;

        public SecretWallLeftSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(xPos, yPos, width, height);
        }

        public override void Disable()
        {
            enabled = false;
            SoundController.Instance.PlayFindSecretSound();
        }

        public override void Update()
        {
            
        }
    }
}
