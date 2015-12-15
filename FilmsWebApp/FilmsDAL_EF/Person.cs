namespace FilmsDAL_EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            MovieToPerson = new HashSet<MovieToPerson>();
        }

        public Guid PersonId { get; set; }

        public long KinopoiskId { get; set; }

        public string EnglishName { get; set; }

        public string RussianName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieToPerson> MovieToPerson { get; set; }
    }
}
