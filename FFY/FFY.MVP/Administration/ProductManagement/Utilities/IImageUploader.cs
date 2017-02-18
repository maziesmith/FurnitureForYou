using System.Web;
using System.Web.UI.WebControls;

namespace FFY.MVP.Administration.ProductManagement.Utilities
{
    public interface IImageUploader
    {
        string Upload(FileUpload Image, HttpServerUtility Server, string imageFileName, string folderName);
    }
}
