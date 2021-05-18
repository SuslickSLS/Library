namespace Library.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Readers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Readers()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        public int Reader_ticket { get; set; }

        [Required]
        [StringLength(100)]
        public string Reader_surname { get; set; }

        [Required]
        [StringLength(100)]
        public string Reader_name { get; set; }

        [Required]
        [StringLength(100)]
        public string Reader_MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(150)]
        public string address { get; set; }

        [NotMapped]
        public int ReaderTicket
        {
            get
            {
                return Reader_ticket + 1000;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
