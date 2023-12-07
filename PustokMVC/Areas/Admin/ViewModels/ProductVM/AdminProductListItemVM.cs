using PustokMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokMVC.Areas.Admin.ViewModels.ProductVM
{
    public class AdminProductListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public Category? Category { get; set; }
    }
}
