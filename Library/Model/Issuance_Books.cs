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

        [NotMapped]
        public string BookName
        {
            get
            {
                return Books.Book_title;
            }
        }

        [NotMapped]
        public string ReaderName
        {
            get
            {
                return Order.Readers.Reader_surname + " " + Order.Readers.Reader_name + " " + Order.Readers.Reader_MiddleName;
            }
        }


        [NotMapped]
        public DateTime DateStart
        {
            get
            {
                return Order.Date_order;
            }
        }

        [NotMapped]
        public DateTime DateEnd
        {
            get
            {
                return Order.Date_end_order;
            }
        }
    }
}
