using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WebBeading
{
    public interface IPaletteColor
    {
        /**
     * Returns integer value of RGB color.
     * @return
     */
        int getRGB();

        /**
         * Returns color as RR.GG.BB.
         * All parts without leading zeroes, for example: 0.10.255.
         * @return
         */
        String getStringRGB();

        /**
         * Loading the picture from data base.
         * Parameter "isLighted" responsible for type of image in data base.
         * @param isLighted
         * @return
         */
        Mat getImage(bool isLighted);

        /**
         * Generates the picture by RGB color.
         * @return generated picture.
         */
        Mat getOneColorImage();

        /**
         * Returns array of 3 integer elements: red, green, blue.
         * @return Array of 3 integer elements: red, green, blue.
         * Each value is integer number from 0 to 255.
         */
        int[] getRGBArray();

        /**
         * Calculate difference between this color and another.
         * For calculation uses RGB representation. Delta will
         * be calculated as: (r1 - r2) ^ 2 + (g1 - g2) ^ 2 + (b1 - b2) ^ 2.
         * @param RGB
         * @return (r1 - r2) ^ 2 + (g1 - g2) ^ 2 + (b1 - b2) ^ 2.
         */
        int getRGBDelta(int RGB);

        int getRGBDelta(IPaletteColor color);

    }
}
