using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CentricProject_Team10.Models
{
    public class userData
    {
        public Guid ID { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Full Name")]
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
        [Display(Name = "Office Location")]
        public string officeLocation { get; set; }
        [Display(Name = "Position Description")]
        public string position { get; set; }
        [Display(Name = "First Day of Employment")]
        public DateTime startDate { get; set; }
    }
}