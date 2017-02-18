using System;
using System.Web;
using System.Web.UI.WebControls;

namespace FFY.MVP.Administration.ProductManagement.AddProduct
{
    public class UploadImageEventArgs
    {
        public UploadImageEventArgs(FileUpload image, 
            string imageFileName,
            HttpServerUtility server)
        {
            if(image == null)
            {
                throw new ArgumentNullException("FileUpload cannot be null.");
            }

            if(string.IsNullOrEmpty(imageFileName))
            {
                throw new ArgumentNullException("Image file name cannot be null.");
            }

            if (server == null)
            {
                throw new ArgumentNullException("Server cannot be null.");
            }

            this.Image = image;
            this.ImageFileName = imageFileName;
            this.Server = server;
        }

        public FileUpload Image { get; set; }

        public string ImageFileName { get; set; }

        public HttpServerUtility Server { get; set; }
    }
}
