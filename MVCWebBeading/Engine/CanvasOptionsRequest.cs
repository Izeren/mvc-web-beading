using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBeading
{
    public class CanvasOptionsRequest
    {
        public int width { get; set; }
        public int height { get; set; }
        public int bixelWidth { get; set; }
        public int bixelHeight { get; set; }
        public string pathToTheImage { get; set; }
    }
}