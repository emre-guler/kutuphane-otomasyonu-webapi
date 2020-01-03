using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProjectBackend.Models
{
    public class UserAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string tcId { get; set; }
        public int deleteState { get; set; }
    }
}