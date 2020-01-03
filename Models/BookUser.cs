using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProjectBackend.Models
{
    public class BookUser 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int bookId { get; set; }
        public int customerId { get; set; }
        public DateTime giveBook { get; set; }
        public DateTime receiveBook { get; set; }
        public int state { get; set; }
    }
}