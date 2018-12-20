using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.Views
{
    public class AddEvent
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string EvenementName { get; set; }
        [Display(Name = "Description")]
        public string EventDesc { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DataType("datetime-local")]
        public DateTime? DateEvent { get; set; }
        [Required]
        [Display(Name = "Lieu")]
        public ListLocalityEvent IdEvent { get; set; }
        public IEnumerable<ListLocalityEvent> ListEventPlace { get; set; }
    }
}