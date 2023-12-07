using PustokMVC.Models;

namespace PustokMVC.Areas.Admin.ViewModels.ProductImagesVM
{
    public class AdminProductImagesListItemVM
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public Product Product { get; set; }
        public bool IsActive { get; set; }
    }
}
