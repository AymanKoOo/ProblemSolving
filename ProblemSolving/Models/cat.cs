using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProblemSolving.Models
{
    public class cat
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category of Problems")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Problem> problem { get; set; }

    }
}