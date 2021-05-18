namespace Library.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            Issuance_Books = new HashSet<Issuance_Books>();
        }

        [Key]
        public int Book_id { get; set; }

        [Required]
        [StringLength(150)]
        public string Book_title { get; set; }

        [Required]
        [StringLength(150)]
        public string Author { get; set; }

        public int Genre_id { get; set; }

        public int Number_pages { get; set; }

        public int Publisher_id { get; set; }

        public int Year_publication { get; set; }

        public int LBC_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string AuthorSign { get; set; }

        public int count { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual LBC LBC { get; set; }

        public virtual Publisher Publisher { get; set; }

        [NotMapped]
        public string Genrename
        {
            get
            {
                return Genre.Genre1;
            }
        }


        [NotMapped]
        public string PublisherName
        {
            get
            {
                return Publisher.Publisher1;
            }
        }

        [NotMapped]
        public string LBCName
        {
            get
            {
                return LBC.LBC_index;
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Issuance_Books> Issuance_Books { get; set; }
    }
}
