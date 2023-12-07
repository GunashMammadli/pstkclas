using System.ComponentModel.DataAnnotations;

namespace PustokMVC.ViewModels
{
    public class SliderListItemVM
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }
        public string Image { get; set; }
    }
}
