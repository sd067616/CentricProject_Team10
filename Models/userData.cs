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
        [Display(Name = "Full Name")]
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Email Address")]

        public string emailAddress { get; set; }
        [Display(Name = "Phone Number")]
        public string phoneNumber { get; set; }
        [Display(Name = "Office Location")]
        public string officeLocation { get; set; }
        [Display(Name = "Position Description")]
        public string position { get; set; }
        [Display(Name = "First Day of Employment")]
        public DateTime startDate { get; set; }
        public ICollection<userRecognition> UserRecognition { get; set; }
    }
}