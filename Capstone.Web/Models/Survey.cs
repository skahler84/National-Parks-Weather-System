using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        [Required(ErrorMessage = "Park selection is required.")]
        public string parkCode { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email address required.")]
        [StringLength(25, ErrorMessage = "Entry can be no more than 25 characters.")]
        public string emailAddress { get; set; }

        [Required(ErrorMessage = "Please select a State.")]
        public string state { get; set; }

        [Required(ErrorMessage = "Please select an Activity Level.")]
        public string activityLevel { get; set; }


    }
}
