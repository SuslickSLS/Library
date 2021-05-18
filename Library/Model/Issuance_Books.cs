namespace Library.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Issuance_Books
    {
        [Key]
        public int Issuance_id { get; set; }

        public int Order_id { get; set; }

        public int Books_id { get; set; }

        public int? Result_books { get; set; }

        public virtual Books Books { get; set; }

        public virtual Order Order { get; set; }
    }
}
