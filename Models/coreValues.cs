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
        public string valueName { get; set; }
        public string valueDescription { get; set; }
        public ICollection<userRecognition> UserRecognition { get; set; }
    }
}