using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactWeb2019.Models
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name="State")]
        [Required(ErrorMessage ="Name of State is required")]
        [StringLength(ContactWebConstants.MAX_STATE_NAME_LENGTH)]
        public string Name { get; set; }

        [Required(ErrorMessage ="State Abbreviation is required")]
        [StringLength(ContactWebConstants.MAX_STATE_ABBR_LENGTH)]
        public string Abbreviation { get; set; }
    }
}