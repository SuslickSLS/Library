namespace Library.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LBC")]
    public partial class LBC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LBC()
        {
            Books = new HashSet<Books>();
        }

        [Key]
        public int LBC_id { get; set; }

        [Required]
        [StringLength(150)]
        public string LBC_name { get; set; }

        [Required]
        [StringLength(50)]
        public string LBC_index { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Books> Books { get; set; }
    }
}
