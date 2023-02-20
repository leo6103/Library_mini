using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) 
        {
        
        }
        public DbSet<Library.Models.User> User { get; set; } = default!;
        public DbSet<Library.Models.Book> Books { get; set; } = default!;
    }
}
