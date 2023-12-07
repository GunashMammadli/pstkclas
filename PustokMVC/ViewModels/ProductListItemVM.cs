using PustokMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokMVC.ViewModels
{
    public class ProductListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
