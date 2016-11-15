using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBeading
{
    public interface IPalette
    {
        /**
        * Adds one more color to the palette.
        * @param color
        */
        void addColor(IPaletteColor color);

        /**
         * Deletes color from the palette by ref.
         * @param color
         */
        void deleteColor(IPaletteColor color);

        /**
         * This method replace one color with another.
         * This is NOT recommended method, because it's
         * impossible to cancel operation.
         * @param oldColor
         * @param newColor
         */
        void replaceColor(IPaletteColor oldColor, IPaletteColor newColor);

        /**
         * Returns closest color int palette.
         * @param RGB
         * @return Reference to the closest color, or null if there is
         * no any color in the palette.
         */
        IPaletteColor getClosest(int RGB);

        /**
         * Returns the array of colors of the palette.
         * @param colors
         */
        IPaletteColor[] getArrayOfColors();
    }
}
