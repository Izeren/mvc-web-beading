using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBeading
{
    public class Bixel : IBixel
    {
        private IPaletteColor color;

        public Bixel(IPaletteColor color)
        {
            this.color = color;
        }

        public Bixel()
        {
            color = null;
        }

        /**
         * Returns the color, which that bixel refer to.
         *
         * @return color which that bixel refer to.
         */
        public IPaletteColor getColor()
        {
            return color;
        }

        /**
         * Sets the color, which that bixel refer to.
         *
         * @param color
         */
        public void setColor(IPaletteColor color)
        {
            this.color = color;
        }
    }
}