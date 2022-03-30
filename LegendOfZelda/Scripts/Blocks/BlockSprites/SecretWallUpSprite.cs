using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class SecretWallUpSprite : BasicBlock
    {
        private const int xPos = 815, yPos = 11, width = 32, height = 32;

        public SecretWallUpSprite(Texture2D blockSpriteSheet)
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
