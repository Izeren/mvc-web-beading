using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBeading
{
    public interface IBixel
    {
        /**
        * Returns the color, which that bixel refer to.
        * @return color which that bixel refer to.
        */
        IPaletteColor getColor();

        /**
         * Sets the color, which that bixel refer to.
         * @param color
         */
        void setColor(IPaletteColor color);
    }
}
