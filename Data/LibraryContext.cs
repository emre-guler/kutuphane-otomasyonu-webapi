using LibraryProjectBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryProjectBackend.Data{
    public class LibraryContext : DbContext 
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
        public DbSet<AdminAccount> AdminAccounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookUser> BookUsers { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}