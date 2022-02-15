using LegendOfZelda.Content.Links.State;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static LegendOfZelda.Content.Items.WeaponManager;

namespace LegendOfZelda.Content.Links
{
    public interface ILink
    {
        ILinkState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
