using PustokMVC.Models;

namespace PustokMVC.Areas.Admin.ViewModels.ProductImagesVM
{
    public class ProductsImagesUpdateVM
    {
        public string ImagePath { get; set; }
        public Product Product { get; set; }
        public bool IsActive { get; set; }
    }
}
