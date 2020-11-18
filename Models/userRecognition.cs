using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CentricProject_Team10.Models
{
    public class userRecognition
    {
        [Key]
        public int recognitionID { get; set; }
        [Display(Name = "Core Value Displayed")]
        public int valueID { get; set; }
        [Display(Name = "Employee Recognized")]
        public Guid ID { get; set; }
        [Display(Name = "Other Comments")]
        public string recognitionComment { get; set; }
        public virtual userData UserData  { get; set; }
        public virtual coreValues CoreValues { get; set; }

    }
}