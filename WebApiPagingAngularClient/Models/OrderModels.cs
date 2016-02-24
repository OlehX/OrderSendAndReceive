
using System.ComponentModel.DataAnnotations;

namespace WebApiPagingAngularClient.Models
{
    public class OrderModels
    {

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "SName")]
        public string SName { get; set; }
        
        public string Company { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
       
        public string Date { get; set; }
    }
}