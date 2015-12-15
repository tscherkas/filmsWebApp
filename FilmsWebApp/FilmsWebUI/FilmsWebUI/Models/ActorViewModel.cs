using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmsWebUI.Models
{
    public class ActorViewModel
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="You must put name") ]
        [StringLength(100,ErrorMessage ="Name must be not greater than 100 characters")]
        public string name { get; set; }
        [Range(typeof(DateTime), "1/1/1700", "3/4/2015",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime date { get; set; }

    }
}