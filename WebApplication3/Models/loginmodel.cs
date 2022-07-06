using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class loginmodel
    {
        public int id { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]

        public string password { get; set; }
    }
}