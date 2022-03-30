using LegendOfZelda.Scripts.Links.Sprite;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Scripts.Links.State
{
    class BackAttackLinkState : BasicLinkState
    {
        public BackAttackLinkState(ILink link, Vector2 position, bool isDamaged, int scale)
        {
            direction = 1;
            this.Link = link;
            this.Position = position;
            this.isDamaged = isDamaged;
            this.Sprite = new BackAttackLinkSprite(LoadLink.linkBackAttack, position, isDamaged, scale);
        }

    }
}
