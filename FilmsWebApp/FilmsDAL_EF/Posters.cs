namespace FilmsDAL_EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Posters
    {
        [Key]
        [Column(Order = 0)]
        public Guid MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PosterId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
