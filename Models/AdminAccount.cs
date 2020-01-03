using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProjectBackend.Models
{
    public class AdminAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string tcId { get; set; }
    }
}