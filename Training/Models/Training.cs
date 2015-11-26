using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training.Models
{
    public class Training
    {
        public int Id { get; set; }

        [Display(Name = "Training name")]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}