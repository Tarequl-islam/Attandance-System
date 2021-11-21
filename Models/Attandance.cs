using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttandanceSystem.Models
{
    public class Attandance
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Person")]
        public int PersonId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name ="Entry or Outgoing")]
        public int IsEntryId { get; set; }

    }
}