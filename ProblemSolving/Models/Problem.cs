using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProblemSolving.Models
{
    public class Problem
    {
        public int ProblemID { get; set;}
        [Required]
        [DisplayName("Problem Name")]
        public string ProblemName { get; set;}


        [Required]
        [DisplayName("Problem Description")]
        public string ProblemDescription { get; set; }

        public int catId { get; set; }

        [DisplayName("Image")]
        public string probImg { get; set; }
       
        public DateTime date;

        //forign key
        public virtual cat Category { get; set; }
        public virtual ICollection<SubProblem> Subproblem { get; set; }

    }
}