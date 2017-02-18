using System;
using System.Web;
using System.Web.UI.WebControls;

namespace FFY.MVP.Administration.ProductManagement.Utilities
{
    public class UploadImageEventArgs
    {
        public UploadImageEventArgs(FileUpload image,
            HttpServerUtility server,
            string imageFileName,
            string folderName)
        {
            if (image == null)
            {
                throw new ArgumentNullException("FileUpload cannot be null.");
            }

            if (server == null)
            {
                throw new ArgumentNullException("Server cannot be null.");
            }

            if (string.IsNullOrEmpty(imageFileName))
            {
                throw new ArgumentNullException("Image file name cannot be null.");
            }

            if (string.IsNullOrEmpty(folderName))
            {
                throw new ArgumentNullException("Folder name cannot be null.");
            }

            this.Image = image;
            this.Server = server;
            this.ImageFileName = imageFileName;
            this.FolderName = folderName;
        }

        public FileUpload Image { get; set; }

        public HttpServerUtility Server { get; set; }

        public string ImageFileName { get; set; }

        public string FolderName { get; set; }
    }
}
