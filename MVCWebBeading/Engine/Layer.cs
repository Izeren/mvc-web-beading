using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emgu.CV;

namespace WebBeading
{
    public class Layer : ILayer
    {
        public LayerOptions options { get; set; }
        public Mat image { get; private set; }

        public Layer(Mat image)
        {
            this.image = image;
        }

        /**
         *
         * @param image
         * @param options
         */
        public Layer(Mat image, LayerOptions options)
        {
            this.options = options;
            this.image = ImageProcessing.bixilizeImage(image, options);
        }
    }
}