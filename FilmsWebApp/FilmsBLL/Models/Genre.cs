using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsBLL.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="Name must contain not more than 50 characters")]
        public string name { get; set; }
    }
}
