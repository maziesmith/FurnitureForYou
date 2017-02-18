using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace FFY.MVP.Administration.ProductManagement.Utilities
{
    public class ImageUploader : IImageUploader
    {
        public string Upload(FileUpload Image, HttpServerUtility Server, string imageFileName, string folderName)
        {
            if (Image.HasFile)
            {
                if (Image.PostedFile.ContentType == "image/png" || Image.PostedFile.ContentType == "image/jpeg")
                {
                    string subPath = @"~\Images\" + folderName;

                    bool exists = Directory.Exists(Server.MapPath(subPath));

                    if (!exists)
                    {
                        Directory.CreateDirectory(Server.MapPath(subPath));
                    }

                    // Not testable, but if we want to assure uniqueness of a file name we have to use some random factor
                    imageFileName = (DateTime.Now - new DateTime(1970, 1, 1)).TotalMinutes.ToString() + Path.GetFileName(Image.FileName);

                    Image.SaveAs(Server.MapPath(subPath + @"\" + imageFileName));

                    return imageFileName;
                }
            }

            return imageFileName;
        }
    }
}
