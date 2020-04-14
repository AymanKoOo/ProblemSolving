using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProblemSolving.Models
{
    public class SubProblem
    {
        public int id { get; set; }
        [Required]
        [DisplayName("Enter Problem Name")]
        public string SubProbName { get; set; }

        [Required]
        [DisplayName("Enter Problem Description")]
        public string SubProbNameDescription { get; set; }

        public int problemId { get; set; }

        [DisplayName("Image")]
        public string probImg { get; set; }

        [Required]
        [DisplayName("Enter Code")]

        public string code { get; set; }

        public DateTime date;

        public virtual Problem problem { get; set; }
    }
}