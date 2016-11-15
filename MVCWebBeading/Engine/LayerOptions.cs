using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBeading
{
    public class LayerOptions
    {
        public int width { get; set; }
        public int height { get; set; }
        public int bixelWidth { get; set; }
        public int bixelHeight { get; set; }
        public WaysOfBixelColorDefinition wayOfBixelColorDefinition { get; set; }
        public IPalette palette { get; set; }
        public LayerOptions(
            int width,
            int height,
            int bixelWidth,
            int bixelHeight,
            WaysOfBixelColorDefinition wayOfBixelColorDefinition,
            Palette palette)
        {
            this.width = width;
            this.height = height;
            this.bixelHeight = bixelHeight;
            this.bixelWidth = bixelWidth;
            this.wayOfBixelColorDefinition = wayOfBixelColorDefinition;
            this.palette = palette;
        }
    }
}