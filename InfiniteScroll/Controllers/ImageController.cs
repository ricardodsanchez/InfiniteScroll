using System.Linq;
using System.Web.Mvc;

namespace InfiniteScroll.Controllers
{
    public class ImageController : Controller
    {
        public void Show(int id)
        {
            AdventureWorksEntities _data = new AdventureWorksEntities();
            byte[] image = _data.ProductPhotoes.Where(x => x.ProductPhotoID == id).SingleOrDefault().ThumbNailPhoto;

            Response.Buffer = true;

            Response.Clear();

            Response.ContentType = "image/gif";

            Response.BinaryWrite(image);

            Response.End();
        }
    }
}