using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class LockedDoorSpriteDown : BasicBlock
    {
        public LockedDoorSpriteDown(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(881, 11, 32, 32);
            transparency = 1f;
        }

        public override void Disable()
        {
            enabled = false;
            SoundController.Instance.PlayOpenDoorSound();
        }

        public override void Update()
        {

        }
    }
}
