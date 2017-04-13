using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InfiniteScroll.Controllers
{
    public class HomeController : Controller
    {
        AdventureWorksEntities _data = new AdventureWorksEntities();
        const int recordsPerPage = 8;

        public ActionResult Index(int? id)
        {
            var page = id ?? 0;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Products", GetPaginatedProducts(page));
            }

            return View("Index", _data.Products.Where(x => x.ProductLine != null).Take(recordsPerPage));
        }

        public ActionResult Product(int? id)
        {
            var page = id ?? 0;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Products", GetPaginatedProducts(page));
            }

            return View("Index", _data.Products.Where(x => x.ProductLine != null).Take(recordsPerPage));
        }

        private List<Product> GetPaginatedProducts(int page = 1)
        {
            var skipRecords = page * recordsPerPage;

            return _data.Products.Where(x => x.ProductLine != null)
                .OrderBy(x=>x.Name)
                .Skip(skipRecords)
                .Take(recordsPerPage).ToList();
        }
    }
}
