using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSM.Models.TempModel
{
    public class ContactEntity
    {
        
        public int id { get; set; }
        [Required(ErrorMessage ="Please enter customer's last name")]
        [StringLength(255)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public System.DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string emails { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Url]
        public string Sites { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [Range(10000,999999999)]
        public string Zip { get; set; }
        public string Comment { get; set; }

    }
}