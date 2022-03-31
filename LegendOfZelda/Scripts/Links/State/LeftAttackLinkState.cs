using LegendOfZelda.Scripts.Links.Sprite;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Scripts.Links.State
{
    class LeftAttackLinkState : BasicLinkState
    {
        public LeftAttackLinkState(ILink link, Vector2 position, bool isDamaged, int scale)
        {
            direction = 2;
            this.Link = link;
            this.Position = position;
            this.isDamaged = isDamaged;
            this.Sprite = new LeftAttackLinkSprite(LoadLink.linkLeftAttack, position, isDamaged, scale);
        }

    }
}
