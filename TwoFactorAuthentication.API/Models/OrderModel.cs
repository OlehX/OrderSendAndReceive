using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwoFactorAuthentication.API.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public string SName { get; set; }

        public string Company { get; set; }
     
        public string City { get; set; }
     
        public string Address { get; set; }
       
        public double Price { get; set; }

        public string Date { get; set; }
       
    }
}