namespace FilmsDAL_EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieToPerson")]
    public partial class MovieToPerson
    {
        [Key]
        [Column(Order = 0)]
        public Guid MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid PersonId { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte DepartmentId { get; set; }

        [StringLength(512)]
        public string Role { get; set; }

        public virtual Department Department { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Person Person { get; set; }
    }
}
