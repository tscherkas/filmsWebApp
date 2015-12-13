namespace FilmsDAL_EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AppUsers
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string user { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string password { get; set; }
    }
}
