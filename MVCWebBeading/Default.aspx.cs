using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using Emgu.CV;
using Emgu.CV.CvEnum;


namespace WebBeading
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                CanvasOptionsRequest rsvp = new CanvasOptionsRequest();

                if (TryUpdateModel(rsvp, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    Repository.GetRepository().AddResponse(rsvp);
                    if (rsvp.pathToTheImage == "" || rsvp.pathToTheImage == null)
                    {
                        Response.Redirect(@"/Content/respond.html");
                    }
                    else
                    {
                        string path = rsvp.pathToTheImage;
                        Mat image = new Mat(path, LoadImageType.Color);
                        LayerOptions options = new LayerOptions(
                            rsvp.width,
                            rsvp.height,
                            rsvp.bixelWidth,
                            rsvp.bixelHeight,
                            WaysOfBixelColorDefinition.ClosestFromPaletteToAverage,
                            new Palette()
                        );
                        Console.WriteLine("{0}", rsvp.width);
                        Console.WriteLine("{0}", rsvp.height);
                        Console.WriteLine("{0}", rsvp.bixelWidth);
                        Console.WriteLine("{0}", rsvp.bixelHeight);
                        Layer layer = new Layer(image, options);
                        Mat newImage = layer.image;
                        //CvInvoke.Imwrite("temp.jpg", newImage, 1);
                        //Response.Redirect(@"/Content/respond.html");
                    }
                }
            }
        }
    }
}