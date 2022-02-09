using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links
{
    interface ILinkState: ILink
    {
        void LoadTexture();
    }
}
