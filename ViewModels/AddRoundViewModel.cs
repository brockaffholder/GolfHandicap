using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicap.ViewModels
{
    public class AddRoundViewModel
    {
        [Required]
        [Display(Name = "Course Name")]
        public string Course { get; set; }
        [Required]
        [Display(Name = "Par")]
        [Range(1, int.MaxValue, ErrorMessage = "Par Score must be greater than {1}")]
        public int Score { get; set; }
        [Required]
        [Display(Name = "Slope Rating")]
        [Range(55, 155, ErrorMessage = "Slope Rating for {0} must be between {1} and {2}")]
        public int Slope { get; set; }
        [Required]
        [Display(Name = "Course Rating")]
        [Range(1, int.MaxValue, ErrorMessage = "Course Rating must be greater than {1}")]
        public float Rating { get; set; }


        //public float ScoreDifferential { get; set; }


    }
}
