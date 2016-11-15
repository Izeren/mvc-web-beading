using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace WebBeading
{
    public class ImageProcessing
    {
        /**
     *
     * @param image
     * @param options
     * @return
     */
        public static Mat bixilizeImage(Mat image, LayerOptions options)
        {

            //Calculating appropriate sizes
            int bixelWidth = options.bixelWidth;
            int bixelHeight = options.bixelHeight;
            int width = (image.Cols / bixelWidth) * bixelWidth;
            int height = (image.Rows / bixelHeight) * bixelHeight;
            int bixeledHeight = image.Rows / bixelHeight;
            int bixeledWidth = image.Cols / bixelWidth;

            Bixel[][] bixels = new Bixel[bixeledHeight][];
            for (int i = 0; i < bixeledHeight; ++i) {
                bixels[i] = new Bixel[bixeledWidth];
            }
            Mat newImage = new Mat(height, width, DepthType.Cv8U, 3);
            for (int i = 0; i < bixeledHeight; ++i)
            {
                for (int j = 0; j < bixeledWidth; ++j)
                {
                    Rectangle rect = new Rectangle(j * bixelWidth, i * bixelHeight, bixelWidth, bixelHeight);
                    Mat subImage = new Mat(image, rect);
                    bixels[i][j] = new Bixel(defineColor(subImage, options));
                    int[] rgbArray = bixels[i][j].getColor().getRGBArray();
                    Mat newImageRegion = new Mat(newImage, rect);
                    newImageRegion.SetTo(new MCvScalar(rgbArray[2], rgbArray[1], rgbArray[0]));
                }
            }
            return newImage;
        }


        private static IPaletteColor defineColor(Mat image, LayerOptions options)
        {
            IPalette palette = options.palette;
            switch (options.wayOfBixelColorDefinition)
            {
                case WaysOfBixelColorDefinition.MostPopularOfClosestToPalette:
                    return defineColorMPOCTP(image, palette);
                case WaysOfBixelColorDefinition.ClosestFromPaletteToAverage:
                    return defineColorCFPTA(image, palette);
                case WaysOfBixelColorDefinition.ClosestFromPaletteToMedian:
                    return defineColorCFPTM(image, palette);
                default:
                    return defineColorMPOCTP(image, palette);
            }
        }
        //MostPopularOfClosestToPalette
        private static IPaletteColor defineColorMPOCTP(Mat image, IPalette palette)
        {
            int width = image.Cols;
            int height = image.Rows;
            Dictionary<IPaletteColor, int> popularity = new Dictionary<IPaletteColor, int>();
            IPaletteColor[] colors = palette.getArrayOfColors();
            for (int i = 0; i < colors.Length; ++i)
            {
                popularity.Add(colors[i], 0);
            }

            IPaletteColor currentPaletteColor;
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    int []indices = { j, i };
                    IPaletteColor color = new PaletteColor(image.GetData(indices));
                    currentPaletteColor = palette.getClosest(color.getRGB());
                    popularity[currentPaletteColor] += 1;
                }
            }
            return Utils.getMostPopularColorFromDict(popularity);
        }

        private static IPaletteColor defineColorCFPTA(Mat image, IPalette palette)
        {
            int[] RGBSum = { 0, 0, 0 };
            int[] indices = { 0, 0 };
            for (indices[0] = 0; indices[0] < image.Cols; ++indices[0])
            {
                for (indices[1] = 0; indices[1] < image.Rows; ++indices[1])
                {
                    byte[] bgr = image.GetData(indices);
                    for (int colorId = 0; colorId < 3; ++colorId)
                    {
                        RGBSum[colorId] = bgr[2 - colorId];
                    }
                }
            }
            int[] average = { 0, 0, 0 };
            for (int colorId = 0; colorId < 3; ++colorId)
            {
                average[colorId] = RGBSum[colorId] / image.Cols * image.Rows;
            }
            return palette.getClosest((new PaletteColor(average)).getRGB());
        }

        private static IPaletteColor defineColorCFPTM(Mat image, IPalette palette)
        {
            int[] RGBSum = { 0, 0, 0 };
            int[] indices = { 0, 0 };
            int size = image.Cols * image.Rows;
            List<int> redColors = new List<int>(size);
            List<int> greenColors = new List<int>(size);
            List<int> blueColors = new List<int>(size);

            for (indices[0] = 0; indices[0] < image.Cols; ++indices[0])
            {
                for (indices[1] = 0; indices[1] < image.Rows; ++indices[1])
                {
                    byte[] bgr = image.GetData(indices);
                    redColors.Add(bgr[2]);
                    greenColors.Add(bgr[1]);
                    blueColors.Add(bgr[0]);
                }
            }
            redColors.Sort();
            greenColors.Sort();
            blueColors.Sort();
            int[] median;
            if (size % 2 == 1)
            {
                median = new int[]{ redColors[size / 2], greenColors[size / 2], blueColors[size / 2]};
            }
            else
            {
                median = new int[3];
                median[0] = (redColors[size / 2] + redColors[size / 2 - 1]) / 2;
                median[1] = (greenColors[size / 2] + greenColors[size / 2 - 1]) / 2;
                median[2] = (blueColors[size / 2] + blueColors[size / 2 - 1]) / 2;
            }
            return palette.getClosest((new PaletteColor(median)).getRGB());
        }
    }
}