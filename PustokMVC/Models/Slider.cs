using System.ComponentModel.DataAnnotations;

namespace PustokMVC.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string BookName { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required, MaxLength(20)]
        public string ButtonText { get; set; }
        [Required]
        public string Image {  get; set; }
    }
}
