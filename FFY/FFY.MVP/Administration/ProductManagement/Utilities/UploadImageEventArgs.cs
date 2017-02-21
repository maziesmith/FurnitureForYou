using System;
using System.Web;
using System.Web.UI.WebControls;

namespace FFY.MVP.Administration.ProductManagement.Utilities
{
    public class UploadImageEventArgs : EventArgs
    {
        public UploadImageEventArgs(FileUpload image,
            HttpServerUtility server,
            string imageFileName,
            string folderName)
        {
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
