using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CentricProject_Team10.Models
{
    public class coreValues
    {
        [Key]
        public int valueID { get; set; }
        [Display(Name = "Core Value")]
        public string valueName { get; set; }
        [Display(Name = "Core Value Description")]
        public string valueDescription { get; set; }
        public ICollection<userRecognition> UserRecognition { get; set; }
    }
}