namespace Library.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Issuance_Books = new HashSet<Issuance_Books>();
        }

        [Key]
        public int Order_id { get; set; }

        public int Readers_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_order { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_end_order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Issuance_Books> Issuance_Books { get; set; }

        public virtual Readers Readers { get; set; }
    }
}
