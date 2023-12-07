using PustokMVC.Models;

namespace PustokMVC.Areas.Admin.ViewModels.ProductImagesVM
{
    public class ProductImageCreateVM
    {
        public IFormFile ImageFile { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; }
    }
}
