using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBeading
{
    public enum StartPaletteSettings {
        EMPTY, WEB_SAFE
    }
    public class Palette : IPalette
    {
        private IList<IPaletteColor> colors { get; set; }

        public Palette(StartPaletteSettings start_color_set = StartPaletteSettings.EMPTY)
        {
            switch(start_color_set)
            {
                case StartPaletteSettings.EMPTY: 
                    {
                        colors = new List<IPaletteColor>();
                        break;
                    }
                case StartPaletteSettings.WEB_SAFE:
                    {
                        setWithWebSafePalette();
                        break;
                    }
                default:
                    break;
            }
        }

        public void setWithWebSafePalette()
        {
            colors = new List<IPaletteColor>();
            for (int red = 0; red < 256; red += 51)
            {
                for (int green = 0; green < 256; green += 51)
                {
                    for (int blue = 0; blue < 256; blue += 51)
                    {
                        colors.Add(new PaletteColor(red, green, blue));
                    }
                }
            }
        }

        /**
         * Adds one more color to the palette.
         *
         * @param color
         */
        public void addColor(IPaletteColor color)
        {
            colors.Add(color);
        }

        /**
         * Deletes color from the palette by ref.
         *
         * @param color
         */
        public void deleteColor(IPaletteColor color)
        {
            colors.Remove(color);
        }

        /**
         * This method replace one color with another.
         * This is NOT recommended method, because it's
         * impossible to cancel operation.
         *
         * @param oldColor
         * @param newColor
         */
        public void replaceColor(IPaletteColor oldColor, IPaletteColor newColor)
        {
            deleteColor(oldColor);
            addColor(newColor);
        }

        /**
         * Returns closest color int palette.
         *
         * @param RGB
         * @return Reference to the closest color, or null if there is
         * no any color in the palette.
         */
        public IPaletteColor getClosest(int color)
        {
            if (colors.Count == 0)
            {
                return null;
            }
            else {
                int delta = colors[0].getRGBDelta(color);
                IPaletteColor currentClosest = colors[0];
                foreach (IPaletteColor paletteColor in colors)
                {
                    int currentDelta = paletteColor.getRGBDelta(color);
                    if (currentDelta < delta)
                    {
                        currentClosest = paletteColor;
                        delta = currentDelta;
                    }
                }
                return currentClosest;
            }
        }

        public IPaletteColor fastGetClosest(int RGB) { return new PaletteColor();  }

        /**
         * Returns the array of colors of the palette.
         * @return the array of colors of the palette.
         */
        public IPaletteColor[] getArrayOfColors()
        {

            int size = this.colors.Count;
            IPaletteColor[] colors = new IPaletteColor[size];
            object[] temp = this.colors.ToArray<object>();
            for (int i = 0; i < size; ++i)
            {
                colors[i] = (IPaletteColor)temp[i];
            }
            return colors;
        }
    }
}