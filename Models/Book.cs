using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProjectBackend.Models
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string bookName { get; set; }
        public string Author { get; set; }
        public string bookPage { get; set; }
        public int lentState { get; set; }
        public int deleteState { get; set; }
    }
}